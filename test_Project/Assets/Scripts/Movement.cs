using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float horizontalInput;
    private Rigidbody2D rb;
    public float speed;
    public float jumpVelocity = 20.0f;
    public Animator animator;
    public bool isOnGround = true;
    public ParticleSystem explosion;
    public bool ifWin;
    public AudioClip jumpSound;
    public float direction;
    private Rigidbody2D rigidbody1;
    public float dashSpeed = 1;
    public float playerXEnd;
    public float dashLength;
    private AudioSource playerSound;
    public bool kickhit = false;
    public int inputcounter;
    public float combonumber;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rigidbody1 = GetComponent<Rigidbody2D>();
        rb = transform.GetComponent<Rigidbody2D>();
        playerSound = GetComponent<AudioSource>();
        inputcounter = 0;
        combonumber = 0;
        animator.SetInteger("comboint", 0);
        StartCoroutine(Countdown2());
    }
    private IEnumerator Countdown2()
    {
        while (true)
        {
            yield return new WaitForSeconds(3.0f); //wait 2 seconds
            if (inputcounter < 2)
            {
                SwitchFromKick();

                Debug.Log("0");
                inputcounter = 0;
                
            }                        //do thing
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ifWin == false)
        {
 
            //horizontal movement dependent on the horizontalInput variable which goes from -1 to 0 to 1
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
            //animator changes speed from 0 to 1 for animation parameters. 
            //if speed is greater than 0.01 (0), then run animation plays.
            //otherwise, speed will be zero, which is less than 0.01 and therefore, idle plays. 
            animator.SetFloat("speed", Mathf.Abs(horizontalInput));

            if ((isOnGround == false))
            {
                if ((Input.GetKeyDown(KeyCode.K)))
                {
                    //kickhit = true;
                    //rb.gravityScale = 0;
                    animator.SetBool("isJumping", false);
                    animator.SetBool("IfKick", true);
                    animator.SetTrigger("Kick");
                    Invoke("SwitchFromKick", 0.25f);
                    animator.SetBool("isJumping", true);
                    //rb.gravityScale = 4.5f;
                    //kickhit = false;
                }
                if ((Input.GetKeyDown(KeyCode.F)))
                {
                    
                    animator.SetBool("isJumping", false);
                    animator.SetBool("IfSlice", true);
                    animator.SetTrigger("SliceTrig");
                    Invoke("SwitchFromKick", 1.0f);
                    animator.SetBool("isJumping", true);
                    
                }

            }

            //if space is pressed and the bool isOnGround is true, then jump.
            //once jump, set the bool to false to avoid double jump
            //set the animation to jumping by setting its respective bool to true
            if (Input.GetKeyDown(KeyCode.Space) && isOnGround && (animator.GetBool("IfKick") == false))
            {
                rb.velocity = Vector2.up * jumpVelocity;
                playerSound.PlayOneShot(jumpSound, 1.0f);
                animator.SetTrigger("JumpTrig");
                animator.SetBool("isJumping", true);
                isOnGround = false;
                

            }
            if ((rb.velocity.y < -0.01) && (animator.GetBool("isDash") == false) && (animator.GetBool("IfKick") == false))
            {
                animator.SetBool("isJumping", true);
                animator.SetTrigger("JumpTrig");


            }

          
            //next two are dash. pressing mouse keys lead to dashing
            //input leads bool jump to false and animation for dashing to true.
            //two if statements for either direction
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

                DashLeft();
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                DashRight();
            }


            if (inputcounter == 2)
            {
                //Debug.Log("hit tttt it!");
                Invoke("SwitchFromKick", 0.0f);
                inputcounter = 0;
            }



            if (inputcounter == 0)
            {
                if (Input.GetKeyDown(KeyCode.K))
                {
                    animator.SetBool("IfKick", true);
                    animator.SetTrigger("Kick");
                    Invoke("delay", 0.33f);
                }
            }

            if (inputcounter == 1)
            {
                if (Input.GetKeyDown(KeyCode.K))
                {
                    animator.SetBool("IfKick", true);
                    animator.SetTrigger("flamekick");
                    Invoke("delay", 0.33f);
                } 
            }
            

            if ((Input.GetKeyDown(KeyCode.F)))
            {
                animator.SetBool("IfSlice", true);
                animator.SetTrigger("SliceTrig");
                Invoke("SwitchFromSlice", 0.86f);
            }



            //flips sprite depending on direction of movement indicated by key input
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                GetComponent<SpriteRenderer>().flipX = false;
                direction = -1;
            }


            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Mouse1))
            {
                GetComponent<SpriteRenderer>().flipX = true;
                direction = 1;
            }

            if (rb.velocity.y < 0)
            {
                animator.SetFloat("speed", 0);
            }
        

        }

    }
    //function for switching dash animation off after set time (invoke).
    //after dash movement done, this animation stops playing
    void SwitchAnimationsDash()
    {
        animator.SetBool("isDash", false);
        rb.velocity = new Vector2(0, 0);
        
    }
    
    void SwitchFromKick()
    {
        animator.SetBool("IfKick", false);
        //animator.ResetTrigger("Kick");
    }

    void delay()
    {
        inputcounter += 1;
        animator.SetBool("IfKick", false);
        
        Debug.Log(inputcounter);
    }

    void SwitchFromSlice()
    {
        animator.SetBool("IfSlice", false);
    }

    //collision detector for preventing double jump. 
    void OnCollisionEnter2D(Collision2D collision)
    {
        isOnGround = true;
        animator.SetBool("isJumping", false);
        if (collision.gameObject.CompareTag("Projectile"))
        {
            explosion.Play();

        }
        if (collision.gameObject.CompareTag("enemy"))
        {
            //explosion.Play();

        }
    



    }
    void DashLeft()
    {
        animator.SetBool("isJumping", false);
        
        rb.velocity = Vector2.left * jumpVelocity * dashSpeed;
        animator.SetBool("isDash", true);
        
        Invoke("SwitchAnimationsDash", 0.25f);
        


    }
    void DashRight()
    {
        animator.SetBool("isJumping", false);
        
        rb.velocity = Vector2.right * jumpVelocity * dashSpeed;
        animator.SetBool("isDash", true);
        
        Invoke("SwitchAnimationsDash", 0.25f);
        


    }
    


}
        