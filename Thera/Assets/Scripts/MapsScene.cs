using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapsScene : MonoBehaviour
{
    // Start is called before the first frame update

    public void ChangeScene(string MapsScene)
    {
        SceneManager.LoadScene(MapsScene);
    }

}
