using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    public LayerMask whatIsObject;
    public Transform grabpoint;
    public float objectCheckDistance;

    private PlayerMovement movement;

    [Header("Animation")]
    private Animator animator;

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();        
    }
    void Start()
    {
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(grabpoint.position, Vector2.right *movement.facingDir , objectCheckDistance, whatIsObject);
        if (hit && Input.GetKey(KeyCode.E))
        {
            movement.canFlip = false;
            hit.rigidbody.mass = 1f;
            hit.transform.position = transform.position - new Vector3(1 * -movement.facingDir,0,0);
            animator.SetBool("Pull", true);
        }

        if (Input.GetKeyUp(KeyCode.E) && hit)
        {
            hit.rigidbody.mass = 200f;
            movement.canFlip = true;
            animator.SetBool("Pull", false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(grabpoint.position, new Vector3(grabpoint.position.x + objectCheckDistance * movement.facingDir, grabpoint.position.y));
    }

}
