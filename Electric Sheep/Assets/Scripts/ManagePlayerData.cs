using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ManagePlayerData
{



    public static void AutoSave() //Add Sheep Stats
    {

        PlayerPrefs.SetString("lastCo", System.DateTime.UtcNow.ToBinary().ToString());
        
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