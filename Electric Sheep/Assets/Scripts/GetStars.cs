using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GetStars : MonoBehaviour
{
    public int score = 0;
    public GameObject canvasAgain;
    public GameManager gm;

    public AudioSource mainmusic;
    public AudioSource getIt;
    public AudioSource miss;


    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        mainmusic = FindObjectOfType<GameManager>().GetComponent<AudioSource>();
        mainmusic.mute = true;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bonus")
        {
            getIt.Play();
            score++;
            collision.transform.SetPositionAndRotation(new Vector3 (collision.transform.position.x, 350, 0), Quaternion.identity) ;
            Debug.Log(score);
            Debug.Log("Bonus");
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Miss")
        {
            miss.Play();
            canvasAgain.SetActive(true);
            Credits.playerCredit += score;
            Destroy(this.gameObject);
            Debug.Log("You loose");
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Run");

    }

    public void GoBack()
    {
        mainmusic.mute = false;

        SceneManager.LoadScene("MainScene");

    }
}
