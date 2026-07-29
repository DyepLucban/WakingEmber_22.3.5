using UnityEngine;

public class Player : MonoBehaviour
{
    #region Components
    public PlayerInputControl inputControl { get; private set; }
    private StateMachine stateMachine;
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    #endregion

    #region States
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpAscendState jumpAscendState { get; private set; }
    public PlayerJumpDescendState jumpDescendState { get; private set; }
    #endregion

    #region Movement Variables
    [Header("Movement Variables")]
    public Vector2 moveInput { get; private set; }
    public bool isJumpPressed;
    public bool isFacingRight = true;
    [SerializeField] public float movementSpeed;
    [SerializeField] public float jumpForce;
    [SerializeField] public float aerialMovement;
    #endregion

    #region Collision Detections
    [SerializeField] public Transform groundChecker;
    [SerializeField] public Vector2 groundCheckerSize;
    [SerializeField] LayerMask groundLayer;
    #endregion
    private void Awake()
    {
        // Components
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();

        // Controls
        stateMachine = new StateMachine();
        inputControl = new PlayerInputControl();

        // States
        idleState = new PlayerIdleState(this, stateMachine, "isIdle");
        moveState = new PlayerMoveState(this, stateMachine, "isMoving");
        jumpAscendState = new PlayerJumpAscendState(this, stateMachine, "isJumping");
        jumpDescendState = new PlayerJumpDescendState(this, stateMachine, "isJumping");
    }

    private void OnEnable()
    {
        inputControl.Enable();

        // Movement        
        inputControl.Player.Movement.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputControl.Player.Movement.canceled += ctx => moveInput = Vector2.zero;

        // Jump
        inputControl.Player.Jump.performed += ctx => isJumpPressed = true;
        inputControl.Player.Jump.canceled += ctx => isJumpPressed = false;
    }

    private void OnDisable()
    {
        inputControl.Disable();
    }

    private void Start()
    {
        stateMachine.Initialize(idleState);
    }

    private void Update()
    {
        stateMachine.currentState.Update();
    }

    public bool isGrounded() => Physics2D.OverlapBox(groundChecker.position, groundCheckerSize, 0, groundLayer);

    public void setVelocity(float xVelocity, float yVelocity)
    {
        rb.linearVelocity = new Vector2(xVelocity, yVelocity);
        handleFlip(xVelocity);
    }

    public void flip()
    {
        transform.Rotate(0, 180f, 0);
        isFacingRight = !isFacingRight;
    }

    public void handleFlip(float xVelocity)
    {
        if (xVelocity > 0 && !isFacingRight)
            flip();
        else if (xVelocity < 0 && isFacingRight)
            flip();
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundChecker.position, groundCheckerSize);       
    }
}
