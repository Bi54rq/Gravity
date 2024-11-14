using UnityEngine;

public class SwitchGravity : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool top;  // To track if gravity is flipped
    private bool canToggleGravity = false;  // Flag to control when gravity toggle is allowed

    void Start()
    {
        // Get references to the necessary components
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if the "Q" key is pressed and if gravity toggle is allowed
        if (Input.GetKeyDown(KeyCode.Q) && canToggleGravity)
        {
            rb.gravityScale *= -1;  // Flip gravity scale
            Rotation();  // Flip the player's sprite based on gravity
        }
    }

    void Rotation()
    {
        // If gravity is flipped, change the player's scale on the X axis to -1 (flip horizontally)
        if (!top)
        {
            // Flip the player's sprite horizontally (by inverting the x-axis scale)
            transform.localScale = new Vector3(-1f, 1f, 1f); // Flip player to face the opposite direction
        }
        else
        {
            // Reset the player's scale to its original state (normal facing right)
            transform.localScale = new Vector3(1f, 1f, 1f); // Ensure player faces right again
        }

        top = !top;  // Toggle the gravity flip state for next time
    }

    // When the player enters the trigger zone, allow gravity toggle
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GravityZone"))  // Assuming the trigger zone has the tag "GravityZone"
        {
            canToggleGravity = true;  // Enable gravity toggle
        }
    }

    // When the player exits the trigger zone, disable gravity toggle
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("GravityZone"))  // Assuming the trigger zone has the tag "GravityZone"
        {
            canToggleGravity = false;  // Disable gravity toggle
        }
    }
}
