using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToVulcano : MonoBehaviour
{
    public void ChangeScene(string scene = "VulcanoLvl")
    {
        SceneManager.LoadScene(sceneName: "VulcanoLvl");
    }



    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("VulcanoLvl");
        }

    }
}
