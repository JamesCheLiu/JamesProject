using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePointer : MonoBehaviour
{
    
    public SpawnManager ifSpawn;
    // Start is called before the first frame update
    void Start()
    {
        ifSpawn = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("DeSpawnPointer", 0.1f);
    }
    void DeSpawnPointer()
    {
        if (ifSpawn.ifSpawned == true)
        {
            Destroy(gameObject);
            ifSpawn.ifSpawned = false;
        }
        
    }
}
