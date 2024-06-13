using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyattack : MonoBehaviour
{
    public GameObject player;
    public float playerX;
    public float playerY;
    private Rigidbody2D rb;
    public GameObject enemy;
    private float SameX;
    private float selfX;
    private float selfY; 
    private Health fullhealth;
    public float health;
    public GameObject bomb;
    public GameObject groundattack;
    public GameObject groundattack2;
    public float launchspeed = 20.0f;
    private float launchfactor;
    //private bool ifstab = true;
    public float speed;
    public float stablocation;

    // Start is called before the first frame update
    void Start()
    {
        fullhealth = enemy.GetComponent<Health>();
        InvokeRepeating("bombToss", 1.0f, 1.0f);
        //InvokeRepeating("groundattack", 1.0f,0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        health = fullhealth.healthfull;
        if (health > 0)
        {
            playerX = player.transform.position.x;
            playerY = player.transform.position.y + 10f;
        }   
    }
    void bombToss()
    {
        if (health > 0)
        {
            if (player.transform.position.x > 15 && player.transform.position.y > 12)
            {
                speed = Random.Range(1.0f, 5.0f);
                Invoke("DelaySpawn", 1.0f);
                Invoke("stabdelay", 1.0f);
            }
            
        }
    }
    void DelaySpawn()
    {
        if (health > 0)
        {
            if (playerX > 10.0)
            {
                //Vector2 playerlocation = new Vector2(playerX, playerY);
                Vector2 spawnlocation = new Vector2(28.1f, 15.05f);
                var bombPrefab = Instantiate(bomb, spawnlocation, transform.rotation);
                rb = bombPrefab.GetComponent<Rigidbody2D>();
                speed = Random.Range(5f, 15f);
                rb.velocity = speed * Vector2.left + (speed / 5) * Vector2.down;
            }
            
        } 
        //bombPrefab.transform.position = Vector2.MoveTowards(spawnlocation, playerlocation, speed * Time.deltaTime);
    }

    
    
    

}
