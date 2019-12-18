using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Credits : MonoBehaviour
{
    public static int playerCredit = 0;
    public Text text;
    private int creditText;

    public void Start()
    {
        text.text = "Credits : " + playerCredit;
        creditText = playerCredit;
    }

    public void Update()
    {
        if(creditText != playerCredit)
        {
            text.text = "Credits : " + playerCredit;
            creditText = playerCredit;
        }
    }
}
