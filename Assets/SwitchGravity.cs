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
            Rotation();  // Flip the player sprite and rotate it upside down
        }
    }

    void Rotation()
    {
        // Flip the gravity by modifying the X axis scale and rotating the player
        if (!top)
        {
            // Flip the player upside down (rotate 180 degrees on the Z-axis)
            transform.eulerAngles = new Vector3(0, 0, 180f);  // Rotate player 180 degrees around the Z-axis

            // Flip the player horizontally by changing the X scale to -1
            transform.localScale = new Vector3(-1f, 1f, 1f);  // Flip player sprite horizontally
        }
        else
        {
            // Reset the rotation and scale back to default when gravity is flipped back
            transform.eulerAngles = Vector3.zero;  // Reset rotation back to normal (Z = 0)
            transform.localScale = new Vector3(1f, 1f, 1f);  // Reset scale to normal (X = 1)
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
