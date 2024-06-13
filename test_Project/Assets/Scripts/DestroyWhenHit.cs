using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenHit : MonoBehaviour
{
    public GameObject player;
    private Vector3 startPos;
    public AudioClip crashSound;
    private AudioSource crashSource;

    // Start is called before the first frame update
    void Start()
    {
        startPos = new Vector3(0, 0, 0);
        crashSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            crashSource.PlayOneShot(crashSound, 1.0f);
            collision.gameObject.transform.position = startPos;
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            crashSource.PlayOneShot(crashSound, 1.0f);
            Destroy(gameObject);
            
         
        }
    }
}
