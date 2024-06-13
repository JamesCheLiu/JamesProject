using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{
    public GameObject player;
    public float playerx;
    public Movement player_rb;
    //private Vector3 offset = new Vector3(0, 0, -10f);
    public float leftlimit;
    public float rightlimit;
    public float upperlimit;
    public float lowerlimit;
    public float offset;
    // Start is called before the first frame update
    void Start()
    {
        player_rb = player.GetComponent<Movement>();
        //1.14
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > leftlimit && player.transform.position.x < rightlimit)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + offset, -5);
        }
        //transform.position = player.transform.position + offset;
        else
        {
            if (player.transform.position.x < leftlimit)
            {
                transform.position = new Vector3(leftlimit, player.transform.position.y + offset, -5);

            }
            if (player.transform.position.x > rightlimit)
            {
                transform.position = new Vector3(rightlimit, player.transform.position.y + offset, -5);
            }

            
        }
        


    }
}
