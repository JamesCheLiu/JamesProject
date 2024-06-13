using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketexplosion : MonoBehaviour
{
    public GameObject player;
    private Vector3 startPos;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        anim.Play("boom");
        Invoke("destroy", 0.12f);


    }

    void destroy()
    {
        Destroy(gameObject);
    }
}
