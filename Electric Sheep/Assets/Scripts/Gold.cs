using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    public static int playerGold = 0;
    public Text text;

    public void Start()
    {
        text.text = "Gold : " + playerGold;
    }
}
