using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    DateTime startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = DateTime.UtcNow;
        Debug.Log(startTime);

        
    }


    // Update is called once per frame
    void Update()
    {
        TimeSpan calculateTime = -(startTime - DateTime.UtcNow); // Calculate Time Differences between start time and this frame !
        Debug.Log(calculateTime);
    }
}
