using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ManagePlayerData
{



    public static void AutoSave(float mood, float food, float clean, float mecanic) //Add Sheep Stats
    {

        PlayerPrefs.SetString("lastCo", System.DateTime.UtcNow.ToBinary().ToString());

        PlayerPrefs.SetFloat("mood", mood);
        PlayerPrefs.SetFloat("food", food);
        PlayerPrefs.SetFloat("clean", clean);
        PlayerPrefs.SetFloat("mecanic", mecanic);

        Debug.Log("Auto-Saving this date to prefs: " + System.DateTime.UtcNow);
    }

    public static void QuitApp()
    {
        //Save the current system time as a string in the player prefs class
        PlayerPrefs.SetString("lastCo", System.DateTime.UtcNow.ToBinary().ToString());

        Debug.Log("Saving this date to prefs: " + System.DateTime.UtcNow);

        Application.Quit();
    }

}