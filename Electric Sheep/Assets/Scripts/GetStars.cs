using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetStars : MonoBehaviour
{
    public int score = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "star")
        {
            score++;
            Destroy(collision.gameObject);
            Debug.Log(score);
            Debug.Log("Star");
        }
    }
}
