using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    
    public GameObject player;
    private Playermanager dmgboosternum;
    // Start is called before the first frame update
    void Start()
    {
        dmgboosternum = player.GetComponent<Playermanager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    
    if (collision.gameObject.CompareTag("Player"))
        {
            dmgboosternum.dmgboosterscollected += 1;
            
        }
         
        
    }
}
