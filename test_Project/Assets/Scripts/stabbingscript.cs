using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stabbingscript : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    private Health fullhealth;
    public float health;
    public float stablocation;
    // Start is called before the first frame update
    void Start()
    {
        fullhealth = enemy.GetComponent<Health>();
        InvokeRepeating("groundAttack", 5.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        health = fullhealth.healthfull;
        if (health <= 0)
        {
            transform.position = new Vector2(stablocation, 9.3f);
        }
    }
    void groundAttack()
    {
        if (health > 0)
        {
            if (player.transform.position.x > 15 && player.transform.position.y > 12)
            {
                stablocation = Random.Range(15.0f, 30.0f);
                transform.position = new Vector2(stablocation, 9.3f);
                Invoke("delay0", 1.0f);
                Invoke("delay1", 1.5f);
            }
            
        }
        
    }
    void delay0()
    {
        if (health > 0)
        {
            transform.Translate(Vector2.up * 3);
        }
    }
    void delay1()
    {
        if (health > 0)
        {
            transform.Translate(Vector2.down * 3);
        }
    }

}
