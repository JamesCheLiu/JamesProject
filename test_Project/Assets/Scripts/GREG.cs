using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GREG : MonoBehaviour
{
    public GameObject player;
    private Health healthscript;
    public Animator anim;
    public float speed;
    public float currenthealth;
    private Rigidbody2D rb;
    public Playermanager playermanager;
    private float knockback;

    // Start is called before the first frame update
    void Start()
    {
        playermanager = player.GetComponent<Playermanager>();
        knockback = playermanager.knockback;
        anim = GetComponent<Animator>();
        healthscript = GetComponent<Health>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("track", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        currenthealth = healthscript.healthfull;
        
    }
    void destroy()
    {
        Destroy(gameObject);
    }
    void impulseleft()
    {
        speed = Random.Range(2.0f, 5.0f);
        GetComponent<SpriteRenderer>().flipX = false;
        rb.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
    }
    void impulseright()
    {
        speed = Random.Range(2.0f, 5.0f);
        GetComponent<SpriteRenderer>().flipX = true;
        rb.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
    }
    void track()
    {
        
        if (player.transform.position.x > transform.position.x)
        {
            if (player.transform.position.x > 4.61f)
            {
                Invoke("impulseright", 1.0f);
            }
        }
        if (player.transform.position.x < transform.position.x)
        {
            if (player.transform.position.x > 4.61f)
            {
                Invoke("impulseleft", 1.0f);
            }
        }
        if (currenthealth <= 0)
        {
            Debug.Log("dead");
            anim.Play("gregjrflop");
            Invoke("destroy", 0.23f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (player.transform.position.x > transform.position.x)
        {
            rb.AddForce(Vector2.left * knockback, ForceMode2D.Impulse);
        }
        if (player.transform.position.x < transform.position.x)
        {
            rb.AddForce(Vector2.right * knockback, ForceMode2D.Impulse);
        }
    }
}
