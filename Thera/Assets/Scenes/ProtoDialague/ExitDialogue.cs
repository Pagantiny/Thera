using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDialogue : MonoBehaviour
{

        public void ChangeScene(string scene = "Map")
        {
            SceneManager.LoadScene(sceneName: "Map");
        }
    
   
   
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Map");
        }

    }
    
}