using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundScene : MonoBehaviour
{
    public void ChangeScene(string SoundScene)
    {
        SceneManager.LoadScene(SoundScene);
    }

}
