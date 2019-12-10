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
    public GameObject flare;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
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

    }



    public void foodAdd() // Button Function
    {
        if (gm.food <= 90)
        {
            gm.food += 10;
        }
        else if (gm.food > 100)
        {
            gm.food = 100;
        }
        Debug.Log("after : " + gm.food);

    }

    public void moodAdd() // Button Function Link with Guess Number Script !
    {
        SceneManager.LoadScene("GetNumber");

    }

    public void cleanAdd() // Button Function
    {

    }

    public void mecanicAdd() // Button Function
    {
        gm.mecanic += 10f;
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
