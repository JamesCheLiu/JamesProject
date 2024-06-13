using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashCollider : MonoBehaviour
{

    public GameObject player;
    public float DashForce = 20.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            transform.position = new Vector3(player.transform.position.x - 1f, player.transform.position.y, player.transform.position.z);
            Invoke("ReturnToOriginal", 0.5f);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            transform.position = new Vector3(player.transform.position.x + 1f, player.transform.position.y, player.transform.position.z);
            Invoke("ReturnToOriginal", 0.5f);
         
        }
    }
    void ReturnToOriginal()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Projectile"))
        {
            if (collision.gameObject.transform.position.x > player.transform.position.x)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * DashForce, ForceMode2D.Impulse);
            }
            if (collision.gameObject.transform.position.x < player.transform.position.x)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * DashForce, ForceMode2D.Impulse);
            }
        }  
        
    }
}
