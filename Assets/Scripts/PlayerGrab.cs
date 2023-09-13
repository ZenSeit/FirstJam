using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    public LayerMask whatIsObject;
    public Transform grabpoint;
    public float objectCheckDistance;

    private PlayerMovement movement;
    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();        
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(grabpoint.position, Vector2.right *movement.facingDir , objectCheckDistance, whatIsObject);
        if (hit && Input.GetKey(KeyCode.E))
        {
            movement.canFlip = false;
            //hit.rigidbody.bodyType = RigidbodyType2D.Dynamic;
            hit.rigidbody.mass = 0f;
            //hit.rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
            hit.transform.position = transform.position - new Vector3(1 * -movement.facingDir,0,0);
        }

        if (Input.GetKeyUp(KeyCode.E) && hit)
        {
            hit.rigidbody.mass = 200f;
            //hit.rigidbody.bodyType = RigidbodyType2D.Static;
            movement.canFlip = true;


        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(grabpoint.position, new Vector3(grabpoint.position.x + objectCheckDistance * movement.facingDir, grabpoint.position.y));
    }

}
