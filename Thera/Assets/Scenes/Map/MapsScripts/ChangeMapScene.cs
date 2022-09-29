using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeMapScene : MonoBehaviour
{
    public void ChangeScene(string MapsScene)
    {
        SceneManager.LoadScene(MapsScene);
    }
}
