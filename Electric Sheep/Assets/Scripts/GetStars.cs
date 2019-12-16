using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetStars : MonoBehaviour
{
    public GameObject[] gameObjects;
    public int score = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bonus")
        {
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
            Destroy(this.gameObject);
            Debug.Log("You loose");
        }
    }

    private void CreateBonusMiss()
    {
        
    }

}
