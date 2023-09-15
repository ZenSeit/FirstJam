using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivator : MonoBehaviour
{
    public Vector2 ladderNewPosition;
    public float speed;
    public GameObject ladderGameObject;
    public Sprite pressedButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = pressedButton;
            ladderGameObject.transform.position = new Vector2(ladderGameObject.transform.position.x + ladderNewPosition.x, ladderGameObject.transform.position.y + ladderNewPosition.y);
        }
    }

   
}
