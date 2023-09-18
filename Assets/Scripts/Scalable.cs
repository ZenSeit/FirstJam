using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scalable : MonoBehaviour
{
    public enum Direction
    {
        Right,
        Left
    }
    public GameObject[] stairParts;

    public Direction direction;
    
    

    

    public void changeStair()
    {
        Vector3 step1 = stairParts[1].transform.position;
        Vector3 step2 = stairParts[2].transform.position;
        
        if (direction==Direction.Left)
        {
            step1 = stairParts[0].transform.position;
            step2 = stairParts[1].transform.position;
            
            if ( transform.position.y - step1.y > 0.1f) return;
            stairParts[0].transform.position = new Vector3(step2.x, step2.y - 1f,
                0.0f);
            stairParts[1].transform.position = new Vector3(step1.x, step1.y - 2f,
                0.0f);

            return;
        }
        
        
        if ( transform.position.y - step1.y > 0.1f) return;
        stairParts[1].transform.position = new Vector3(step1.x, step1.y - 1f,
            0.0f);
        stairParts[2].transform.position = new Vector3(step2.x, step2.y - 2f,
            0.0f);
        
        
    }
    
}
