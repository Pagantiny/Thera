using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public string tagForLose;
   
    // Start is called before the first frame update
    void Start()
    {

    }
    public void ChangeScene(string scene = "AkrotiriScene")
    {
        SceneManager.LoadScene(sceneName: "AkrotiriScene");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        { 
            Destroy(other.gameObject);
            Debug.Log("Livello Fallito");
            SceneManager.LoadScene("AkrotiriScene");
        }
    }
}