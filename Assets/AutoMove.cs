using UnityEngine;

public class AutoMove : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;  // Speed 
    public bool moveRight = true; // Direction (true = right, false = left)

    private Rigidbody2D rb;
    private bool isFacingRight;

    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();

        // Set the initial facing direction
        isFacingRight = moveRight;
    }

    void Update()
    {
        // Apply automatic movement based on the direction
        if (moveRight)
        {
            rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y); // right
        }
        else
        {
            rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y); // left
        }

        // Flip the sprite based on movement direction
        Flip();
    }

    private void Flip()
    {
        // If moving right and currently facing left, or if moving left and currently facing right, flip the character
        if ((moveRight && !isFacingRight) || (!moveRight && isFacingRight))
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f; // Flip the sprite by inverting the x scale
            transform.localScale = localScale;
        }
    }
}
