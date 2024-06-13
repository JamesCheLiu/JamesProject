using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > 15 && player.transform.position.y > 12)
        {

            transform.position = new Vector3(13.59f, 13.83f, 0);
        }
        
    }
}
