using UnityEngine;
using UnityEngine.InputSystem;
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
    public Transform groundCheck; // helps handling the isGrounded() method with an horizontal capsule draw at this positon
    private Vector2 capsuleSize = new Vector2(0.55f, 0.17f); // Size obtained by visually measuring the capsule in the scene at the specified Transform
    public LayerMask groundMask; // Layer of the ground to detect whenever the player touch the ground

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
    }

    void Update()
    {
        // Handles a jump buffer for better UX
        if (jump.WasPressedThisFrame() && !isGrounded())
            jumpBuffer = true;

        if (jump.WasPressedThisFrame())
            isJumpPressed = true;

        if (jump.WasReleasedThisFrame())
            isJumpPressed = false;
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

        
        if (rb.velocity.y <= 0)
        {
            rb.velocity -= gravity * characterStats.fallMultiplier * Time.fixedDeltaTime;
        }
    }

    /// <summary>
    /// Checks if the player is grounded.
    /// </summary>
    /// <returns><c>true</c> if the player is grounded; otherwise, <c>false</c>.</returns>
    private bool isGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, capsuleSize, CapsuleDirection2D.Horizontal, 0, groundMask);
    }
    private void LateUpdate()
    {
        animator.SetBool("OnGround", rb.velocity.y== 0);
    }

}

