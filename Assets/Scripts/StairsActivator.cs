using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsActivator : MonoBehaviour
{
    public GameObject stair;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            stair.GetComponent<Scalable>().changeStair();
        }
    }
}
