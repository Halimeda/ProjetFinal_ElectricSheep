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
    }

    private void Update()
    {
        foodStat.text = "Food : " + Convert.ToUInt32(gm.food);
        moodStat.text = "Mood : " + Convert.ToUInt32(gm.mood);
        mecanicStat.text = "Mecanic : " + Convert.ToUInt32(gm.mecanic);
        cleanStat.text = "Clean : " + Convert.ToUInt32(gm.clean);

        if(gm.mecanic < 50)
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



    public void foodAdd() // Button Function
    {
        if (gm.food <= 90)
        {
            if(Credits.playerCredit >= 10)
            {
                gm.food += 10;
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

        Debug.Log("after : " + gm.food);

    }

    public void moodAdd() // Button Function Link with Guess Number Script !
    {
        runner.SetActive(true);
        guessNumber.SetActive(true);
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

        if (gm.clean <= 90 && Credits.playerCredit >= 10)
        {
            if (Credits.playerCredit >= 10)
            {
                test = true;
                bubble.SetActive(true);
                bubble1.SetActive(true);
                bubble2.SetActive(true);
                gm.clean += 10;
                menu.SetActive(false);
                Credits.playerCredit -= 10;
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
        if (gm.mecanic <= 90)
        {
            if (Credits.playerCredit >= 10)
            {
                gm.mecanic += 10;
                Credits.playerCredit -= 10;
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

        Debug.Log("after : " + gm.mecanic);
    }

    public static float foodModifier(float food, TimeSpan deltaTime) //AutoModif down
    {
        float.TryParse(deltaTime.Minutes.ToString(), out float temp);

        food = food - temp * 0.03f;

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

        mood = mood - (((food + mecanic) * 0.03f )- rand) * 0.5f;

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

        mecanic = mecanic - temp * 0.02f - rand;

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

        clean = clean - temp * 0.03f;

        if(clean <= 0)
        {
            clean = 0;
        }

        Debug.Log("Inside clean function  : " + clean);

        return clean;
    }

}
