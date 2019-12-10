using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Credits : MonoBehaviour
{
    public static int playerCredit = 0;
    public Text text;

    public void Start()
    {
        text.text = "Credits : " + playerCredit;
    }
}
