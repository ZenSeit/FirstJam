using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    public LayerMask whatIsObject;
    public Transform grabpoint;
    public float objectCheckDistance;
    public Vector2 offSetGrab;
    private Animator animator;

    public bool canGrab = true;

    private PlayerMovement movement;

    private Animator GrabAnimator;
    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        GrabAnimator = GetComponent<Animator>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(grabpoint.position, Vector2.right *movement.facingDir , objectCheckDistance, whatIsObject);
        if (hit && Input.GetMouseButton(0) && canGrab)
        {
            animator.SetBool("Grab", true);
            movement.canFlip = false;
            //hit.rigidbody.mass = 1f;
            hit.transform.position = transform.position - new Vector3(offSetGrab.x * -movement.facingDir, offSetGrab.y, 0);
        }

        if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("Grab", false);
        }

        if (!hit)
        {
            movement.canFlip = true;
            animator.SetBool("Grab", false);
        }
    }

    public IEnumerator StopGrabbing()
    {
        canGrab = false;
        yield return new WaitForSeconds(0.3f);
        canGrab = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(grabpoint.position, new Vector3(grabpoint.position.x + objectCheckDistance * 1, grabpoint.position.y));
        Gizmos.DrawLine(grabpoint.position, new Vector3(grabpoint.position.x + objectCheckDistance * -1, grabpoint.position.y));
    }

}
