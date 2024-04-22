using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this value to control player movement speed
    public GameObject ballPrefab; // Assign the ball prefab in the Unity editor
    public float throwForce = 10f; // Adjust this value to control the force of the throw
    public KeyCode throwKey = KeyCode.Space; // The key to trigger the throw action

    private Rigidbody2D rb;
    private bool ballThrown = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        rb.velocity = movement;

        if (Input.GetKeyDown(throwKey) && !ballThrown)
        {
            ThrowBall();
            ballThrown = true;
        }
    }

    void ThrowBall()
    {
        // Instantiate a new ball at the player's position
        GameObject newBall = Instantiate(ballPrefab, transform.position, Quaternion.identity);

        // Get the Rigidbody2D component of the new ball
        Rigidbody2D ballRb = newBall.GetComponent<Rigidbody2D>();

        // Apply an upward force to the ball
        ballRb.AddForce(Vector2.up * throwForce, ForceMode2D.Impulse);
    }

    // This method will be called when the ball reaches the ground and is collected back
    public void CollectBallBack()
    {
        ballThrown = false;
    }

    // This method is called when the player collides with another object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with a boundary
        if (collision.gameObject.tag == "Boundary")
        {
            // Perform any actions you want when the player hits a boundary
            // For example, stop the player's movement
            rb.velocity = Vector2.zero;

            // You could also add any other logic here, such as reducing player health,
            // changing the game state, or providing feedback to the player.
        }
    }
}