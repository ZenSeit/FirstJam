using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsActivator : MonoBehaviour
{
    public GameObject stair;
    public Sprite pressedButton;
    AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioManager.PlaySFXSound(audioManager.switchSound);
            gameObject.GetComponent<SpriteRenderer>().sprite = pressedButton;
            stair.GetComponent<Scalable>().changeStair();
        }
    }
}
