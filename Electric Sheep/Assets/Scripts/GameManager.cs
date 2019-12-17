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
    private int waitTime = 10;

    public float mood;
    public float food;
    public float clean;
    public float mecanic;

    private bool checkAutoSave;
    private TimeSpan timeDiff;
    private DateTime lastStatModif;

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
        //PlayerPrefs.DeleteAll();

    }

    void Start()
    {

        Debug.Log(PlayerPrefs.GetString("isNewGame"));
        Debug.Log(PlayerPrefs.GetString("lastCo") + "Player prefs lastco");
        //PlayerPrefs.SetString("lastCo", System.DateTime.Now.ToBinary().ToString());

        if (!PlayerPrefs.HasKey("isNewGame"))
        {
            Debug.Log("isnewgame");
            PlayerPrefs.SetString("isNewGame", "false");
            PlayerPrefs.SetFloat("mood", 80);
            PlayerPrefs.SetFloat("food", 80);
            PlayerPrefs.SetFloat("clean", 0);
            PlayerPrefs.SetFloat("mecanic", 80);
            StartCoroutine(NewSceneWaitandStart());

        }
        else if (PlayerPrefs.GetString("isNewGame") == "false" && SceneManager.GetActiveScene().name == "StartScreen")
        {
            Debug.Log("Only on start scene");
            StartCoroutine(MainSceneWaitandStart());
        }

        checkAutoSave = false;
        mood = PlayerPrefs.GetFloat("mood");
        food = PlayerPrefs.GetFloat("food");
        clean = PlayerPrefs.GetFloat("clean");
        mecanic = PlayerPrefs.GetFloat("mecanic");

        timeDiff = this.FromLastConnexion(startTime);
        //Debug.Log(lastCoDiff + "Timespan last co");
    }


    void Update()
    {
        if(checkAutoSave == false)
        {
            StartCoroutine(AutoSave());
            checkAutoSave = true;
            Debug.Log("start coroutine");
        }
        Debug.Log("update");
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


    IEnumerator MainSceneWaitandStart()
    {
        Debug.Log("start Main Scene");
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("MainScene");
    }

    IEnumerator NewSceneWaitandStart()
    {
        Debug.Log("start Intro Scene");

        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("Intro");

    }

    IEnumerator AutoSave()
    {

        yield return new WaitForSeconds(120);

        //Modify Statistique before autosave.
        TimeSpan dif = -lastStatModif.Subtract(DateTime.UtcNow); //Calculate difference of time between lastautosave and now before modify stat
        lastStatModif = DateTime.UtcNow;

        food = StatModifier.foodModifier(food, dif);
        clean = StatModifier.cleanModifier(clean, dif);
        mecanic = StatModifier.mecanicModifier(mecanic, dif);
        mood = StatModifier.moodModifier(mood, food, mecanic);

        checkAutoSave = false;

        Debug.Log("after : " + food);
        Debug.Log("after : " + mood);
        Debug.Log("after : " + clean);
        Debug.Log("after : " + mecanic);

        ManagePlayerData.AutoSave(mood, food, clean, mecanic);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("lastCo", System.DateTime.Now.ToBinary().ToString());
        PlayerPrefs.SetFloat("mood", mood);
        PlayerPrefs.SetFloat("food", food);
        PlayerPrefs.SetFloat("clean", clean);
        PlayerPrefs.SetFloat("mecanic", mecanic);
    }
}
