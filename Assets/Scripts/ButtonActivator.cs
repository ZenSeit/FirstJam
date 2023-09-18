using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivator : MonoBehaviour
{
    public Vector2 ladderNewPosition;
    public float speed;
    public GameObject ladderGameObject;
    bool activateAnimation = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {            
            activateAnimation = true;
            //ladderGameObject.transform.position = new Vector2(ladderGameObject.transform.position.x + ladderNewPosition.x, ladderGameObject.transform.position.y + ladderNewPosition.y);
        }
    }

    private void Update()
    {
        if(activateAnimation && ladderGameObject.transform.position.y >= ladderNewPosition.y)
        ladderGameObject.transform.Translate(Vector2.up * Time.deltaTime * speed * -1);
    }


}
