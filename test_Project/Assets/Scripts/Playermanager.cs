using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermanager : MonoBehaviour
{
    public float currenthealth;
    public Health health;
    private KickCollider kick;
    public GameObject kickcollider;
    public GameObject player;
    public float dmgboosterscollected;
    public float currentdmg;
    public float knockback = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        kick = kickcollider.GetComponent<KickCollider>();
        health = player.GetComponent<Health>();
        
    }

    // Update is called once per frame
    void Update()
    {
        currentdmg = kick.kickDamage + dmgboosterscollected;
        currenthealth = health.healthfull;
    }
}
