using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterStatsScriptableObject characterStats;

    private PlayerInputActions playerControls;
    private InputAction move;

    private Rigidbody2D rb;

    private Vector2 playerInput;
    private Vector2 desiredSpeed;
    private Vector2 currentSpeed;

    [Header("Animation")]
    private Animator animator;
    [Header("Flip info")]
    public int facingDir = 1;
    public bool isFacingRight = true;
    public bool canFlip = true;

    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerControls = new PlayerInputActions();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
    }

    private void Update()
    {
        playerInput = move.ReadValue<Vector2>();
        animator.SetFloat("Horizontal", Mathf.Abs(playerInput.x));
    }

    private void FixedUpdate()
    {
        if (playerInput != Vector2.zero)
        {
            desiredSpeed = new Vector2(playerInput.x * characterStats.maxSpeed, rb.velocity.y);
            currentSpeed = rb.velocity;
            rb.velocity = Vector2.Lerp(currentSpeed, desiredSpeed, characterStats.acceleration * Time.fixedDeltaTime);
            FlipController(playerInput.x);
        }
        else
        {
            desiredSpeed = new Vector2(0, rb.velocity.y);
            currentSpeed = rb.velocity;
            rb.velocity = Vector2.Lerp(currentSpeed, desiredSpeed, characterStats.deceleration * Time.fixedDeltaTime);
        }
    }

    #region FLip
    private void Flip()
    {
        facingDir = facingDir * -1;
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);

    }

    private void FlipController(float _x)
    {
        if (_x > 0 && !isFacingRight && canFlip)
            Flip();
        else if (_x < 0 && isFacingRight && canFlip)
            Flip();
    }
    #endregion
}

