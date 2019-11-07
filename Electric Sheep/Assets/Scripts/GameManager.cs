using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    private DateTime startTime;
    private DateTime lastConnexion;
    private long temp;
    private int waitTime = 5;

    TimeSpan lastCoDiff;

    private void Awake()
    {
        startTime = DateTime.UtcNow;
        if (gm == null)
        {
            DontDestroyOnLoad(gameObject);
            gm = this;
        }
        else if (gm != this)
        {
            Destroy(gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
        //Debug.Log(startTime + "Strart Time");
        //Debug.Log(PlayerPrefs.GetString("lastCo") + "Player prefs lastco");
        PlayerPrefs.SetString("lastCo", System.DateTime.Now.ToBinary().ToString());

        if (PlayerPrefs.HasKey("isNewGame") == false)
        {
            Debug.Log("isnewgame");
            PlayerPrefs.SetString("isNewGame", "false");
            SceneManager.LoadScene("NewGameOpenScene");
        }
        else if (PlayerPrefs.HasKey("isNewGame") == true && SceneManager.GetActiveScene().name == "StartScreen")
        {
            Debug.Log("Only on start scene");

            StartCoroutine(WaitandStartMainScene());
        }


        lastCoDiff = this.FromLastConnexion(startTime);
        //Debug.Log(lastCoDiff + "Timespan last co");
    }


    // Update is called once per frame
    void Update()
    {
        TimeSpan calculateTime = -(startTime - DateTime.UtcNow); // Calculate Time Differences between start time and this frame !
        //Debug.Log(calculateTime + "Calculate time");
        ManagePlayerData.AutoSave();
        //Debug.Log(PlayerPrefs.GetString("lastCo") + "Player prefs lastco");


    }

    public TimeSpan FromLastConnexion(DateTime startTime)
    {

        temp = Convert.ToInt64(PlayerPrefs.GetString("lastCo"));

        //Convert the old time from binary to a DataTime variable
        lastConnexion = DateTime.FromBinary(temp);
        //Debug.Log("oldDate: " + lastConnexion);

        //Use the Subtract method and store the result as a timespan variable
        TimeSpan difference = startTime.Subtract(lastConnexion);
        //Debug.Log("Difference: " + difference);
        return difference;
    }

    public void playerName()
    {
        Debug.Log("PlayerName");
       

    }

    public void sheepName()
    {

    }

    IEnumerator WaitandStartMainScene()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("MainScene");
    }


}
