using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class StatModifier : MonoBehaviour
{

    public static float foodModifier(float food, TimeSpan deltaTime)
    {
        Debug.Log("Food is modify");
        return food;
    }

    public static float moodModifier(float mood, TimeSpan deltaTime)
    {
        Debug.Log("Mood is modify");
        return mood;
    }

    public static float mecanicModifier(float mecanic, TimeSpan deltaTime)
    {
        Debug.Log("Macanic is modify");
        return mecanic;
    }

    public static float cleanModifier(float clean, TimeSpan deltaTime)
    {
        Debug.Log("Clean is modify");
        return clean;
    }

}
