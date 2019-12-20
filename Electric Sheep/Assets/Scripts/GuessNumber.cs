using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GuessNumber : MonoBehaviour
{
    private int npcNumber;

    public AudioSource mainmusic;
    public AudioSource getIt;

    public Canvas button;
    public InputField input;
    public Text text;
    public GameManager gm;
    private bool isWin;

    private int chance;
    private int credit;

    // Start is called before the first frame update
    void Start()
    {
        mainmusic = FindObjectOfType<GameManager>().GetComponent<AudioSource>();
        mainmusic.mute = true;
        System.Random rdm = new System.Random();
        npcNumber = rdm.Next(0, 10);
        button.enabled = false;
        isWin = false;
        chance = 0;
        credit = 10;
        Debug.Log(npcNumber);
    }

    public void guessNumber()
    {
        int.TryParse(input.text, out int playerNumber);
        chance++;
        Debug.Log(playerNumber);
        if (playerNumber == npcNumber && chance <= 5)
        {
            text.text = ("You find it ! You try " +  chance + " times !");
            if(chance == 1)
            {
                getIt.Play();
                Credits.playerCredit += credit;
                gm.mood += 10;
            }
            else
            {
                Credits.playerCredit += (credit - chance);
                gm.mood += 5; 
            }
            isWin = true;
            button.enabled = true;

        }
        else if(playerNumber < npcNumber && chance < 5)
        {
            text.text = "Oh ! No ! It's too low ... \n \n Try Again !" ;

        }
        else if(playerNumber > npcNumber && chance < 5)
        {
            text.text = "Oh ! No ! It's too high ... \n \n Try Again !";

        }
        if(chance == 5)
        {
            if( isWin == false)
            {
                text.text = "Oh ! No ! You loose ! the number was " + npcNumber + " ! ";

            }

            button.enabled = true;

        }

    }

    public void toMainScene()
    {
        mainmusic.mute = false;

        SceneManager.LoadScene("MainScene");

    }

    public void retry()
    {
        System.Random rdm = new System.Random();
        npcNumber = rdm.Next(0, 10);
        button.enabled = false;
        text.text = "Try to find the number ! ";

        isWin = false;
        chance = 0;
        credit = 10;
        Debug.Log(npcNumber + " restry");
    }
}
