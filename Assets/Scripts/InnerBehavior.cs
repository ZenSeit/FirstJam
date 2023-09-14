using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerBehavior : MonoBehaviour
{
    private GameObject player;   
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Box" || collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Debug.Log("caja");
            player.GetComponent<PlayerGrab>().StartCoroutine("StopGrabbing");
        }
    }


}
