using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TerrainUtils;
/// <summary>
/// Controls the movement of the player character.
/// </summary>
public class PlayerJump : MonoBehaviour
{
    [SerializeField] private CharacterStatsScriptableObject characterStats;

    private PlayerInputActions playerControls;
    private InputAction jump;

    private bool isJumpPressed;
    private bool isJumping;
    private float jumpCounter; // Handles how much extra time the player can jump to get extra height
    private bool jumpBuffer; // to check if the player is using the buffer

    private Vector2 gravity; // to operate easier with gravity

    private Rigidbody2D rb;
    public Transform groundCheck1; // helps handling the isGrounded() method with an horizontal capsule draw at this positon
    public Transform groundCheck2; // helps handling the isGrounded() method with an horizontal capsule draw at this positon
    public Transform groundCheck3; // helps handling the isGrounded() method with an horizontal capsule draw at this positon
    private float raycastDistance = 0.3f;
    public LayerMask groundMask; // Layer of the ground to detect whenever the player touch the ground
    //public LayerMask obstaclesMask;
    //public LayerMask combinedMask;

    [Header("Animation")]
    private Animator animator;
    

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerControls = new PlayerInputActions();
        animator = GetComponent<Animator>();

    }

    private void OnEnable()
    {
        jump = playerControls.Player.Jump;
        jump.Enable();
    }

    private void OnDisable()
    {
        jump.Disable();
    }

    void Start()
    {
        isJumpPressed = false;
        isJumping = false;
        gravity = new Vector2(0, -Physics2D.gravity.y);
        //combinedMask = groundMask | obstaclesMask;
    }

    void Update()
    {
        // Handles a jump buffer for better UX
        if (jump.WasPressedThisFrame() && !isGrounded())
            jumpBuffer = true;

        if (jump.WasPressedThisFrame())
        {
            isJumpPressed = true;
            animator.SetTrigger("Jump");
        }

        if (jump.WasReleasedThisFrame())
            isJumpPressed = false;

        animator.SetBool("OnGround", isGrounded());
        animator.SetFloat("VerticalVelocity", rb.velocity.y);
    }

    void FixedUpdate()
    {
        // Handles jump logic
        if ((isJumpPressed || jumpBuffer) && isGrounded())
        {
            isJumping = true;
            rb.velocity = new Vector2(rb.velocity.x, characterStats.jumpForce);
            jumpCounter = 0;
            jumpBuffer = false;
            
        }

        if (!isJumpPressed)
        {
            jumpCounter = 0;
            jumpBuffer = false;
            isJumping = false;

            // If the player stops jumping, decay the vertical speed by the specified percentage
            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * characterStats.jumpDecayPercentage);
            }
            
        }

        // Handles dynamic jumping and dynamic fall
        if (rb.velocity.y > 0 && isJumping)
        {
            jumpCounter += Time.fixedDeltaTime;
            if (jumpCounter > characterStats.jumpTime)
                isJumping = false;

            float t = jumpCounter / characterStats.jumpTime; // Normalized jump calcule
            float currentJump = characterStats.jumpMultiplier;

            // If the jump is more than halfway through, then apply this formula to generate a more realistic jump
            if (t > 0.5f)
            {
                currentJump = characterStats.jumpMultiplier * (1 - t);
            }

            
            rb.velocity += gravity * currentJump * Time.fixedDeltaTime;
        }

        
        //if (rb.velocity.y <= 0)
        //{
        //    rb.velocity -= gravity * characterStats.fallMultiplier * Time.fixedDeltaTime;
        //}
    }

    /// <summary>
    /// Checks if the player is grounded.
    /// </summary>
    /// <returns><c>true</c> if the player is grounded; otherwise, <c>false</c>.</returns>
    private bool isGrounded()
    {
        return Physics2D.Raycast(groundCheck1.position, Vector2.down, raycastDistance, groundMask) || Physics2D.Raycast(groundCheck2.position, Vector2.down, raycastDistance, groundMask) || Physics2D.Raycast(groundCheck3.position, Vector2.down, raycastDistance, groundMask);
    }


    private void OnDrawGizmos()
    { 
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundCheck1.position, groundCheck1.position + Vector3.down * raycastDistance);
        Gizmos.DrawLine(groundCheck2.position, groundCheck2.position + Vector3.down * raycastDistance);
        Gizmos.DrawLine(groundCheck3.position, groundCheck3.position + Vector3.down * raycastDistance);
    }
}

