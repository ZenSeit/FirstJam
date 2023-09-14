using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivator : MonoBehaviour
{
    public Vector2 ladderNewPosition;
    public float speed;
    public GameObject ladderPrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ladderPrefab.transform.position = new Vector2(ladderPrefab.transform.position.x + ladderNewPosition.x, ladderPrefab.transform.position.y + ladderNewPosition.y);
        }
    }

   
}
