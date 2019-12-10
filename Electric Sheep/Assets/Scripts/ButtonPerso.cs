using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPerso : MonoBehaviour
{
    public GameObject menu;
    private bool isClick;

    private void Start()
    {
        isClick = false;
    }

    public void Menu()
    {
        if (!isClick)
        { 
            menu.SetActive(true);
            isClick = true;

        }
        else
        {
            menu.SetActive(false);
            isClick = false;
        }
    }
}
