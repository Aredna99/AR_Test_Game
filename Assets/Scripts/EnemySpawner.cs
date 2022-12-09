using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(1, 10)]
    public int nEnemies;
    public GameObject[] enemies;
    public GameObject enemyPrefab;
    public Transform enemyParent;

    [Range(0, 5)]
    public float timeBetweenSpawns;
    public float elapsedTimeSpawn;

    PlayerController player;

    private void Start()
    {
        // Insted of spawn every time an Enemy there will be max N enemies
        // active in scene. And insted of destroy them I will just disable
        // them and re-enable on SpawnEnemy call

        enemies = new GameObject[nEnemies];

        for (int i = 0; i < nEnemies; i++)
        {
            enemies[i] = Instantiate(enemyPrefab, enemyParent);
            enemies[i].GetComponent<EnemyController>().dead = true;
            enemies[i].SetActive(false);
        }

        // Just on the start it will spawn enemies after 3 secs
        elapsedTimeSpawn = 3f;

        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (!player.isAlive)
            return;

        if(elapsedTimeSpawn <= 0f)
        {
            SpawnEnemy();
        }
        elapsedTimeSpawn -= Time.deltaTime;
    }

    void SpawnEnemy()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (!enemies[i].gameObject.activeSelf)
            {
                elapsedTimeSpawn = timeBetweenSpawns;

                enemies[i].transform.position = RandomPosAround(player.transform);
                enemies[i].gameObject.SetActive(true);
                enemies[i].GetComponent<EnemyController>().dead = false;
                break;
            }
        }
    }

    Vector3 RandomPosAround(Transform origin)
    {
        float radius = player.radius + 3;
        // With this i will get the rndPos inside the sphere having for the center "origin" 
        Vector3 rndPos = origin.position + Random.insideUnitSphere * radius;

        // I put to the same hight the rndPos for spawn all enemy to the same hight of the "origin"
        rndPos.y = origin.position.y;

        Vector3 direction = rndPos - origin.position;
        direction.Normalize();
        
        // Get the dot product (between 1, -1) using the origin forward and the direction calculated with rndPos
        float dotProduct = Vector3.Dot(origin.forward, direction);

        // the dot product is not enough so i need to get the angle of the dot product and use it for spawn the
        // rndPos both right and left
        float dotProductAngle = Mathf.Acos(dotProduct / origin.forward.magnitude * direction.magnitude);

        rndPos.x = origin.position.x + radius * Mathf.Cos(dotProductAngle);

        // Need to use Random.value > 0.5f ? 1f : -1f) for spawn the objs on both sides
        rndPos.z = origin.position.z + radius * (Random.value > 0.5f ? 1f : -1f) * Mathf.Sin(dotProductAngle);

        return rndPos;
    }
}
