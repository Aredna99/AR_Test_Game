using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    /// There is going to be a Circle collider for the player
    /// So that is I want i could create a "safe area" where enemy
    /// Shouldn't enter. If they enter in this area u get damaged,
    /// And the enemy disappear.
    public bool isAlive;
    [Range(20, 100)]
    public int maxHealth;
    [Range(1, 10)]
    public int radius;

    [SerializeField]
    Slider hp;
    [SerializeField]
    GameObject sphere;
    [SerializeField]
    bool invincible;

    [SerializeField]
    Button invincibleButton;

    int currHealth;
    bool quit;
    SphereCollider sphereCollider;
    SceneMgr sceneMgr;
    // Start is called before the first frame update
    void Start()
    {
        invincible = false;
        isAlive = true;
        quit = false;
        currHealth = maxHealth;
        sphereCollider = GetComponent<SphereCollider>();

        if (invincibleButton == null)
            invincibleButton = GameObject.Find("Invincible Button").GetComponent<Button>();

        sceneMgr = FindObjectOfType<SceneMgr>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive && !quit)
        {
            if(!quit)
            {
                quit = true;
                sceneMgr.LoadNextScene(0);
            }
            return;
        }

        hp.value = ((float)currHealth / maxHealth);
        sphere.transform.localScale = new Vector3(radius * 2, 0.1f, radius * 2);
        sphereCollider.radius = radius;
    }

    // This is going to be called when I will click the Invincible button
    public void ChangeInvincibleState()
    {
        invincible = !invincible;
        if(invincibleButton != null)
            invincibleButton.GetComponent<Image>().color = invincible == true ? Color.green : Color.white;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            if (!invincible)
            {
                currHealth -= 10;
                if (currHealth <= 0)
                    isAlive = false;
            }

            other.GetComponent<EnemyController>().dead = true;
            other.gameObject.SetActive(false);
        }
    }
}
