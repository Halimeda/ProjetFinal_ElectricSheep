using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StatModifier : MonoBehaviour
{
    public GameManager gm;

    public Text foodStat;
    public Text moodStat;
    public Text mecanicStat;
    public Text cleanStat;

    public AudioSource bubblesound;

    public GameObject alert;
    public GameObject button;
    public GameObject runner;
    public GameObject guessNumber;
    public GameObject menu;

    public GameObject flare;
    public GameObject bubble;
    public GameObject bubble1;
    public GameObject bubble2;

    private bool test;



    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        test = false;
        alert.SetActive(false);
        button.SetActive(false);
        runner.SetActive(false);
        guessNumber.SetActive(false);
        foodStat.color = ColorSelection(gm.food);
        moodStat.color = ColorSelection(gm.mood);
        mecanicStat.color = ColorSelection(gm.mecanic);
        cleanStat.color = ColorSelection(gm.clean);
    }

    private void Update()
    {
        foodStat.text = "Food : " + Convert.ToUInt32(gm.food);
        moodStat.text = "Mood : " + Convert.ToUInt32(gm.mood);
        mecanicStat.text = "Mecanic : " + Convert.ToUInt32(gm.mecanic);
        cleanStat.text = "Clean : " + Convert.ToUInt32(gm.clean);

        foodStat.color = ColorSelection(gm.food);
        moodStat.color = ColorSelection(gm.mood);
        mecanicStat.color = ColorSelection(gm.mecanic);
        cleanStat.color = ColorSelection(gm.clean);

        if (gm.mecanic < 50)
        {
            flare.SetActive(true);
        }
        else if(gm.mecanic > 50)
        {
            flare.SetActive(false);

        }
        if(test == false)
        {
            bubble.SetActive(false);
            bubble1.SetActive(false);
            bubble2.SetActive(false);
            Debug.Log("false bubble");

        }

    }

    public Color ColorSelection(float stat)
    {
        if (stat >= 80)
        {
            return(Color.green);
        }

        else if (stat < 80 && stat >= 50)
        {
            return(Color.yellow);
        }
        else if (stat < 50 && stat >= 25)
        {
            return (Color.red);
        }
        else
        {
            return (Color.black);
        }
    }

    public void foodAdd() // Button Function
    {
        runner.SetActive(false);
        guessNumber.SetActive(false);
        if (gm.food <= 90)
        {
            if(Credits.playerCredit >= 5)
            {
                gm.food += 5;
                Credits.playerCredit -= 10;
                menu.SetActive(false);

            }
            else
            {
                alert.SetActive(true);
                button.SetActive(true);
                
            }
            
        }
        else if (gm.food > 100)
        {
            gm.food = 100;
        }
        foodStat.color = ColorSelection(gm.food);
        Debug.Log("after : " + gm.food);

    }

    public void moodAdd() // Button Function Link with Guess Number Script !
    {
        runner.SetActive(true);
        guessNumber.SetActive(true);
        moodStat.color = ColorSelection(gm.mood);
    }

    public void GuessNumber()
    {
        SceneManager.LoadScene("GetNumber");
    }

    public void Runner()
    {
        SceneManager.LoadScene("Run");
    }

    public void OkButton()
    {
        alert.SetActive(false);
        button.SetActive(false);
    }

    public void cleanAdd() // Button Function
    {
        runner.SetActive(false);
        guessNumber.SetActive(false);
        if (gm.clean <= 90)
        {
            if (Credits.playerCredit >= 5)
            {
                bubblesound.Play();
                test = true;
                bubble.SetActive(true);
                bubble1.SetActive(true);
                bubble2.SetActive(true);
                gm.clean += 10;
                Credits.playerCredit -= 5;
                menu.SetActive(false);
                StartCoroutine(Bubble());
            }
            else
            {
                alert.SetActive(true);
                button.SetActive(true);

            }
        }
        else if (gm.clean > 100)
        {
            bubblesound.Play();
            test = true;
            bubble.SetActive(true);
            bubble1.SetActive(true);
            bubble2.SetActive(true);
            gm.clean = 100;
            StartCoroutine(Bubble());
        }
        Debug.Log("after : " + gm.clean);
    }

    IEnumerator Bubble()
    {
        yield return new WaitForSeconds(5f);
        test = false;
        //bubbles[rand].SetActive(false);
        //bubble.SetActive(false);

    }

    public void mecanicAdd() // Button Function
    {
        runner.SetActive(false);
        guessNumber.SetActive(false);
        if (gm.mecanic <= 90)
        {
            if (Credits.playerCredit >= 5)
            {
                gm.mecanic += 10;
                Credits.playerCredit -= 5;
                menu.SetActive(false);
            }
            else
            {
                alert.SetActive(true);
                button.SetActive(true);

            }
        }
        else if (gm.mecanic > 100)
        {
            gm.mecanic = 100;
        }

        mecanicStat.color = ColorSelection(gm.mecanic);

        Debug.Log("after : " + gm.mecanic);
    }

    public static float foodModifier(float food, TimeSpan deltaTime) //AutoModif down
    {
        float.TryParse(deltaTime.Minutes.ToString(), out float temp);

        food = food - temp * 0.3f;

        if(food <= 0)
        {
            food = 0f;
        }
        
        Debug.Log("Food is modify : " + food);
        
        return food;
    }

    public static float moodModifier(float mood, float food, float mecanic) //AutoModif down
    {
        System.Random rdm = new System.Random();
        float rand = rdm.Next(0, 5);

        mood = mood - (((food + mecanic) /2 )- rand);

        if(mood <= 0)
        {
            mood = 0f;
        }

        Debug.Log("Mood is modify : " + mood);       

        return mood;
    }
     
    public static float mecanicModifier(float mecanic, TimeSpan deltaTime) //AutoModif down
    {
        float.TryParse(deltaTime.Minutes.ToString(), out float temp);

        System.Random rdm = new System.Random();
        float rand = rdm.Next(0, 5);

        mecanic = mecanic - temp/2 - rand;

        if(mecanic <= 0)
        {
            mecanic = 0f;
        }

        Debug.Log("Mecanic is modify : " + mecanic);

        return mecanic;
    }

    public static float cleanModifier(float clean, TimeSpan deltaTime) //AutoModif down
    {
        float.TryParse(deltaTime.Minutes.ToString(), out float temp);
        Debug.Log("temp" + temp);

        clean = clean - (temp/2);

        if(clean <= 0)
        {
            clean = 0;
        }

        Debug.Log("Inside clean function  : " + clean);

        return clean;
    }

}
