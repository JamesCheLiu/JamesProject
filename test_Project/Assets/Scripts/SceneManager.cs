using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManager : MonoBehaviour
{
    private int currentScene;
    // Start is called before the first frame update
    void Start()
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
            //Debug.Log(currentScene);
            
            UnityEngine.SceneManagement.SceneManager.LoadScene(currentScene + 1);
            
            
        }
    }
    void StartGame()
    {
        
    }
    
}
