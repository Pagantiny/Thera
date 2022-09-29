using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLabyrinth : MonoBehaviour
{

    public void ChangeScene(string scene = "Labyrinth.2")
    {
        SceneManager.LoadScene(sceneName: "Labyrinth.2");
    }



    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Labyrinth.2");
        }

    }


}
