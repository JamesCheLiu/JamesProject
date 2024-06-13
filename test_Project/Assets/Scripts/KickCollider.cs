using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickCollider : MonoBehaviour
{
    public GameObject player;
    public ParticleSystem boom;
    public Movement directionTrigger;
    private Animator anim;
    public float kickhit = 0.0f;
    public float kickRange;
    public float kickDamage = 5.0f;
    public AudioClip hitsound;
    private AudioSource playerSound;
    public float verticaloffset;
    // Start is called before the first frame update
    void Start()
    {
        directionTrigger = player.GetComponent<Movement>();
        anim = GetComponent<Animator>();
        playerSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if ((Input.GetKeyDown(KeyCode.K)))
        {
            
            kickhit = 1.0f;
            //Debug.Log(kickhit);
            if (directionTrigger.direction == -1)
            {
                transform.position = new Vector3(player.transform.position.x - kickRange, player.transform.position.y - verticaloffset, player.transform.position.z);
            }
            if (directionTrigger.direction == 1)
            {
                transform.position = new Vector3(player.transform.position.x + kickRange, player.transform.position.y - verticaloffset, player.transform.position.z);
            }
            Invoke("ReturnToOriginal", 0.25f);   
        }
    }
    private void OnColliderEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
    }
    void ReturnToOriginal()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        kickhit = 0.0f;
        
    }
    void delay()
    {
        anim.SetBool("ifhit", false);
    }
    
}
