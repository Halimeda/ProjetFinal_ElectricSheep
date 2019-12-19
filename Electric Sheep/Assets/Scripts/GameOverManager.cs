using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverManager : MonoBehaviour
{

    public AudioSource mainmusic;
    public AudioSource gameOver;

    // Start is called before the first frame update
    void Start()
    {
        mainmusic = FindObjectOfType<GameManager>().GetComponent<AudioSource>();
        mainmusic.mute = true;
        PlayerPrefs.DeleteAll();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        PlayerPrefs.DeleteAll();
        mainmusic.mute = false;
        SceneManager.LoadScene("StartScreen");
    }
}
