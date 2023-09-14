using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimbing : MonoBehaviour
{
    private float yInput;
    private Rigidbody2D rb;
    [SerializeField] float ClimbSpeed;
    CapsuleCollider2D myCapsuleCollider;
    float initialGravityScale;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
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
            return;
        }
        Vector2 climbVelocity = new Vector2(rb.velocity.x, yInput * ClimbSpeed);
        rb.velocity = climbVelocity;
        rb.gravityScale = 0f;
    }
}
