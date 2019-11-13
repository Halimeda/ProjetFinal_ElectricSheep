using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveInputs : MonoBehaviour
{
    public InputField playerName;
    public InputField sheepName;
    private bool checkPlayer;
    private bool checkSheep;

    private void Start()
    {
        checkPlayer = false;
        checkSheep = false;
    }

    private void Update()
    {
        if(checkPlayer == true && checkSheep == true)
        {
            Debug.Log("Saveinput");
            SceneManager.LoadScene("MainScene");
        }
    }

    public void SavePlayerName()
    {
        PlayerPrefs.SetString("playerName", playerName.text);
        checkPlayer = true;
        Debug.Log(PlayerPrefs.GetString("playerName"));
    }
    public void SaveSheepName()
    {
        PlayerPrefs.SetString("sheepName", sheepName.text);
        checkSheep = true;
        Debug.Log(PlayerPrefs.GetString("sheepName"));

    }
}
