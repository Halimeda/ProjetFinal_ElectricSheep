using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class StatModifier : MonoBehaviour
{
    


    public static float foodModifier(float food, TimeSpan deltaTime)
    {
        Debug.Log("Food is modify");
        float.TryParse(deltaTime.Minutes.ToString(), out float temp);
        Debug.Log(temp);
        food = food - temp * 0.03f;
        Debug.Log("inside function : " + food);
        return food;
    }

    public static float moodModifier(float mood, float food, float mecanic, TimeSpan deltaTime)
    {
        System.Random rdm = new System.Random();
        float rand = rdm.Next(0, 5);
        mood = mood - (((food + mecanic) * 0.03f )- rand) * 0.5f; 
        Debug.Log("Mood is modify");
        float.TryParse(deltaTime.Minutes.ToString(), out float temp);
        

        return mood;
    }

    public static float mecanicModifier(float mecanic, TimeSpan deltaTime)
    {
        System.Random rdm = new System.Random();
        float rand = rdm.Next(0, 5);

        Debug.Log("Macanic is modify");
        float.TryParse(deltaTime.Minutes.ToString(), out float temp);
        mecanic = mecanic - temp * 0.02f - rand;

        Debug.Log("Inside mecanic function  : " + mecanic);

        return mecanic;
    }

    public static float cleanModifier(float clean, TimeSpan deltaTime)
    {
        Debug.Log("Clean is modify");
        float.TryParse(deltaTime.Minutes.ToString(), out float temp);
        clean = clean - temp * 0.03f;
        Debug.Log("Inside clean function  : " + clean);
        return clean;
    }

}
