using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    Rigidbody body;


    // Start is called before the first frame update
    void Start()
    {

    }


    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Hai trovato l'uscita");
        }
    
    }
    
}
