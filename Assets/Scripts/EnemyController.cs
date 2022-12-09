using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool dead;
    public float speed;
    [SerializeField]
    PlayerController player;

    void Start()
    {
        // This isn't one of the best way to find an obj but it's ok for this time
        if (player == null)
            player = FindObjectOfType<PlayerController>();

        dead = true;
    }

    // Rotate the enemy toward the player and move it towards him
    void Update()
    {
        if (!player.isAlive)
            return;

        transform.forward = player.transform.position - transform.position;
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
