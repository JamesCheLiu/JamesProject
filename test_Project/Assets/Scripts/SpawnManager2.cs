using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager2 : MonoBehaviour
{
    public GameObject greg;
    public Vector3 spawnlocation;
    // Start is called before the first frame update
    void Start()
    {
        //spawnlocation = new Vector3(16.8f, -3.933f, 0);
        Instantiate(greg, spawnlocation, greg.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
