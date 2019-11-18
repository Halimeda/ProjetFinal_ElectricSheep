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

    private float mood;
    private float food;
    private float clean;
    private float mecanic;

    private bool checkAutoSave;
    private TimeSpan timeDiff;
    private DateTime lastStatModif;

    private void Awake()
    {
        PlayerPrefs.DeleteAll();
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
            PlayerPrefs.SetFloat("mood", 80);
            PlayerPrefs.SetFloat("food", 80);
            PlayerPrefs.SetFloat("clean", 80);
            PlayerPrefs.SetFloat("mecanic", 90);
            StartCoroutine(NewSceneWaitandStart());

        }
        else if (PlayerPrefs.HasKey("isNewGame") == true && SceneManager.GetActiveScene().name == "StartScreen")
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


    // Update is called once per frame
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
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("MainScene");
    }

    IEnumerator NewSceneWaitandStart()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("NewGameOpenScene");

    }

    IEnumerator AutoSave()
    {
        Debug.Log(food);
        yield return new WaitForSeconds(120);

        //Modify Statistique before autosave.
        TimeSpan dif = lastStatModif.Subtract(DateTime.UtcNow); //Calculate difference of time between lastautosave and now before modify stat
        lastStatModif = DateTime.UtcNow;
        food = StatModifier.foodModifier(food, dif);
        mood = StatModifier.moodModifier(mood, dif);
        mecanic = StatModifier.mecanicModifier(mecanic, dif);
        clean = StatModifier.cleanModifier(clean, dif);
        checkAutoSave = false;
        ManagePlayerData.AutoSave(mood, food, clean, mecanic);
    }
}
