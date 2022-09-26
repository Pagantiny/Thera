using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LanguageScene : MonoBehaviour
{
    public void ChangeScene(string LanguageScene)
    {
        SceneManager.LoadScene(LanguageScene);
    }
}
