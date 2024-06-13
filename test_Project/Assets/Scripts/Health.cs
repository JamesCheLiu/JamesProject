using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject player;
    private Playermanager playermanager;
    public GameObject entity;
    private KickCollider kick;
    public GameObject kickcollider;
    public float healthfull;
    public AudioClip hitsound;
    private AudioSource soundsource;
    // Start is called before the first frame update
    void Start()
    {
        kick = kickcollider.GetComponent<KickCollider>();
        playermanager = player.GetComponent<Playermanager>();
        soundsource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthfull <= 0)
        {
            Debug.Log("dead");
            if (entity.gameObject.CompareTag("Player"))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (entity.CompareTag("boss"))
        {
            if (kick.kickhit == 1.0f)
            {
                soundsource.PlayOneShot(hitsound, 1.0f);
                healthfull = healthfull - playermanager.currentdmg;
            }
        }
        if (entity.CompareTag("Player") && entity.tag != "kick")
        {
            if (collision.gameObject.CompareTag("enemy"))
            {
                healthfull = healthfull - 1.0f;
            }

        }
        if (entity.CompareTag("enemy"))
        {
            if (kick.kickhit == 1.0f)
            {
                soundsource.PlayOneShot(hitsound, 1.0f);
                healthfull = healthfull - playermanager.currentdmg;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (entity.CompareTag("Player"))
        {
            if (collision.gameObject.CompareTag("enemy"))
            {
                healthfull = healthfull - 1.0f;
            }



        }
    }

}
