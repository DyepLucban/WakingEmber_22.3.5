using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    #region Components
    private Rigidbody2D rb;
    private Animator anim;
    #endregion

    #region Movement Variables
    private float xInput;
    public float movementSpeed = 3.5f;
    public float jumpForce = 5f;
    public bool isFacingRight = true;
    #endregion

    #region Collision Checks
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded;

    #endregion
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        handleCollision();
        handleMovement();
        handleAnimation();
        handleFlip();
    }

    public void handleMovement()
    {
        // Movement
        xInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(xInput * movementSpeed, rb.linearVelocity.y);

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

    }

    public void handleAnimation()
    {
        anim.SetFloat("xVelocity", rb.linearVelocity.x);
        anim.SetFloat("yVelocity", rb.linearVelocity.y);
        anim.SetBool("isGrounded", isGrounded);
    }

    public void flip()
    {
        transform.Rotate(0f, 180f, 0f);
        isFacingRight = !isFacingRight;
    }

    public void handleFlip()
    {
        if (rb.linearVelocityX > 0 && !isFacingRight)
            flip();
        else if (rb.linearVelocityX < 0 && isFacingRight)
            flip();
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, -groundCheckDistance, 0));
    }

    private void handleCollision()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
    }
}
