using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Vector3 targetAngle;
    private Quaternion _targetAngle;
    private Quaternion originAngle;
    public float timeToMove = 2f;

    int sens = 1;
    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _targetAngle = Quaternion.Euler(targetAngle);
        originAngle = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        float t = timer / timeToMove;
        
        if (sens > 0)
        {
            transform.rotation = Quaternion.Lerp(originAngle, _targetAngle, t);
            if(t >= 1f){
                sens = -1;
                timer = 0f;
            }
        }
        else{
            transform.rotation = Quaternion.Lerp(_targetAngle, originAngle, t);
            if(t >= 1f){
                sens = 1;
                timer = 0f;
            }
        }
        
    }
}
