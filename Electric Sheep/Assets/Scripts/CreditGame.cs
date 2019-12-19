using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CreditGame : MonoBehaviour
{
    public void GoBack()
    {
        SceneManager.LoadScene("MainScene");

    }

    public void Credit()
    {
        SceneManager.LoadScene("Credits");

    }
}
