using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampingTrapRL : MonoBehaviour
{
    public float rightSpeed;
    public float leftSpeed;
    public Transform right;
    public Transform left;
    private bool chop;


    void Start()
    {

    }

    void Update()
    {
        if (transform.position.x >= left.position.x)
        {
            chop = true;
           
        }
        if (transform.position.x <= right.position.x)
        {
            chop = false;
            
        }
        if (chop)
        {
            transform.position = Vector2.MoveTowards(transform.position, left.position, leftSpeed * Time.deltaTime);

        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, right.position, rightSpeed * Time.deltaTime); 
            
        }

    }
}
