using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ContinueButton : MonoBehaviour
{
    public void Continue()
    {
        SceneManager.LoadScene("NewGameOpenScene");
    }

    public void ContinueNotNew()
    {
        SceneManager.LoadScene("MainScene");
    }
}
