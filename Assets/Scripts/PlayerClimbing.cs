using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;

public class PlayerClimbing : MonoBehaviour
{
    private float yInput;
    private Rigidbody2D rb;
    [SerializeField] float ClimbSpeed;
    CapsuleCollider2D myCapsuleCollider;
    float initialGravityScale;
    Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        initialGravityScale = rb.gravityScale;
        
    }

    // Update is called once per frame
    void Update()
    {
        yInput = Input.GetAxisRaw("Vertical");
        ClimbLadder();
    }

    void ClimbLadder()
    {

        if(!myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Climbing"))) 
        {
            rb.gravityScale = initialGravityScale;
            animator.SetBool("Climb", false);
            return;
        }

        Vector2 climbVelocity = new Vector2(rb.velocity.x, yInput * ClimbSpeed);
        rb.velocity = climbVelocity;
        rb.gravityScale = 0f;
        bool hasVerticalSpeed= Mathf.Abs(rb.velocity.y) > Mathf.Epsilon;
        animator.SetBool("Climb", true);
        animator.SetBool("Climbing", hasVerticalSpeed);
    }
}
