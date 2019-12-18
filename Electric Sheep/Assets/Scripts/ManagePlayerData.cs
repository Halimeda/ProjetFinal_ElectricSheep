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

        PlayerPrefs.SetInt("credit", Credits.playerCredit);

        Debug.Log("Auto-Saving this date to prefs: " + System.DateTime.UtcNow);
    }

    public static void QuitApp()
    {
        //Save the current system time as a string in the player prefs class
        PlayerPrefs.SetString("lastCo", System.DateTime.UtcNow.ToBinary().ToString());

        PlayerPrefs.SetFloat("mood", GameManager.gm.mood);
        PlayerPrefs.SetFloat("food", GameManager.gm.food);
        PlayerPrefs.SetFloat("clean", GameManager.gm.clean);
        PlayerPrefs.SetFloat("mecanic", GameManager.gm.mecanic);

        PlayerPrefs.SetInt("credit", Credits.playerCredit);

        Debug.Log("Saving this date to prefs: " + System.DateTime.UtcNow);

        Application.Quit();
    }

}