using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject player;
    private float playerX;
    private float playerY;
    private Rigidbody2D rb;
    public GameObject enemy;
    private Vector2 spawnPos;
    public GameObject Pointer;
    private Vector2 pointerSpawn;
    //public GameObject Block;
    //private float BlockY;
    public bool ifSpawned;
    private float SameX;
    public float SpawnDelayFromPointer = 0f;
    public Movement playerController;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        playerController = GameObject.Find("player").GetComponent<Movement>();
        InvokeRepeating("spawn", 2f, 0.3f);
        
            
    }

    // Update is called once per frame
    void Update()
    {
        playerX = player.transform.position.x;
        playerY = player.transform.position.y + 10f;
        //BlockY = Block.transform.position.y;
        

    }
    void spawn()
    {
        if (playerController.ifWin == false)
        {
            Vector2 pointerSpawn = new Vector2(playerX, playerY - 10.0f);
            SameX = pointerSpawn.x;
            Instantiate(Pointer, pointerSpawn, Pointer.transform.rotation);
            ifSpawned = true;
            Invoke("DelaySpawn", SpawnDelayFromPointer);
        }
        
        
    }
    void DelaySpawn()
    {
        Vector2 spawnPos = new Vector2(SameX, playerY);
        Instantiate(enemy, spawnPos, enemy.transform.rotation);
        
    }
    

}
