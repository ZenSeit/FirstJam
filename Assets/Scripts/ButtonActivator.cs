using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivator : MonoBehaviour
{
    public Vector2 ladderNewPosition;
    public float speed;
    public GameObject ladderGameObject;
    bool activateAnimation = false;
    public Sprite pressedButton;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {            
            activateAnimation = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = pressedButton;
            audioManager.PlaySFXSound(audioManager.switchSound);
            //ladderGameObject.transform.position = new Vector2(ladderGameObject.transform.position.x + ladderNewPosition.x, ladderGameObject.transform.position.y + ladderNewPosition.y);
        }
    }

    private void Update()
    {
        if(activateAnimation && ladderGameObject.transform.position.y >= ladderNewPosition.y)
        ladderGameObject.transform.Translate(Vector2.up * Time.deltaTime * speed * -1);
    }


}
