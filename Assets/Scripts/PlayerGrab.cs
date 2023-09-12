using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    public LayerMask whatIsObject;
    public Transform grabpoint;
    public float objectCheckDistance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(grabpoint.position, Vector2.right, objectCheckDistance, whatIsObject);
        if (hit && Input.GetKey(KeyCode.E))
        {
            hit.rigidbody.bodyType = RigidbodyType2D.Dynamic;
            hit.rigidbody.mass = 0f;
            hit.transform.position = transform.position - new Vector3(-1,0,0);
        }

        if (Input.GetKeyUp(KeyCode.E) && hit)
            hit.rigidbody.bodyType = RigidbodyType2D.Static;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(grabpoint.position, new Vector3(grabpoint.position.x + objectCheckDistance, grabpoint.position.y));
    }
    
}
