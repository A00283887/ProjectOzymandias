using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlatformerMovement : MonoBehaviour
{
    private bool canMove = true;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float wallSlideSpeed = 0.75f; // Speed of sliding down the wall
    public LayerMask whatIsWall;
    public Transform wallCheckLeft; // Transform to check for walls on the left
    public Transform wallCheckRight; // Transform to check for walls on the right
    public float wallCheckRadius = 0.2f;
    public Transform groundCheck; // Transform to check if the player is on the ground
    public float groundCheckRadius = 0.2f;
    public LayerMask whatIsGround;

    private Rigidbody2D rb;
    private bool isTouchingWallLeft;
    private bool isTouchingWallRight;
    private bool isWallSliding;
    private float moveInput;
    private bool isGrounded;
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer to flip the character sprite

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        isTouchingWallLeft = Physics2D.OverlapCircle(wallCheckLeft.position, wallCheckRadius, whatIsWall);
        isTouchingWallRight = Physics2D.OverlapCircle(wallCheckRight.position, wallCheckRadius, whatIsWall);
        isWallSliding = (isTouchingWallLeft || isTouchingWallRight) && !isGrounded;

        UpdateMovement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            AttemptJump();
        }

        if (isGrounded && !canMove)
        {
            canMove = true;
        }
    }

    void UpdateMovement()
    {
        if (canMove)
        {
            if (!isWallSliding)
            {
                rb.velocity = new Vector2(moveSpeed * moveInput, rb.velocity.y);
            }
            // Apply a slight force away from the wall if wall sliding to prevent sticking
            else if (isWallSliding)
            {
                float wallDirection = isTouchingWallLeft ? 1f : -1f;
                rb.velocity = new Vector2(moveSpeed * 0.1f * wallDirection, rb.velocity.y);
            }
        }

        if (moveInput > 0)
        {
            spriteRenderer.flipX = false; // Move right, face right
        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = true; // Move left, face left
        }
    }

    void AttemptJump()
    {
        if (isGrounded)
        {
            // Normal jump
            rb.velocity = Vector2.up * jumpForce;
            canMove = true; // Ensure movement is enabled when grounded
        }
        else if (isWallSliding)
        {
            // Wall jump
            float jumpDirection = isTouchingWallLeft ? 1f : -1f; // Determine jump direction based on the wall side
            rb.velocity = new Vector2(jumpForce * jumpDirection, jumpForce); // Apply force diagonally away from the wall
            canMove = false; // Disable movement until grounded
        }
    }

    void OnDrawGizmosSelected()
    {
        if (wallCheckLeft == null || wallCheckRight == null || groundCheck == null)
            return;

        Gizmos.DrawWireSphere(wallCheckLeft.position, wallCheckRadius);
        Gizmos.DrawWireSphere(wallCheckRight.position, wallCheckRadius);
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}