using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ReachGoal : MonoBehaviour
{
    //public Movement goal;
    //public ParticleSystem boom;
    //public Animator player;
    private int currentScene;
    private bool isindoor;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isindoor == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("enter2");
                Invoke("SWITCH", 1.0f);
            }
        }
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("enter");
            isindoor = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("enter");
            isindoor = false;

        }
    }
    void SWITCH()
    {
        currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentScene + 1);
    }
}
