using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 startPos;

    public float throwForce = 10f; // Force applied when throwing the ball
    public float respawnDelay = 2f; // Delay before respawning the ball

    private bool isThrown = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
    }

    private void Update()
    {
        // Check for input to throw the ball
        if (Input.GetKeyDown(KeyCode.Space) && !isThrown)
        {
            ThrowBall();
            isThrown = true;
        }
    }

    private void ThrowBall()
    {
        rb.isKinematic = false; // Allow physics to affect the ball
        rb.AddForce(Vector3.up * throwForce, ForceMode.Impulse); // Apply upward force to the ball
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the ball collides with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isThrown = false; // Reset the thrown state
            Invoke("RespawnBall", respawnDelay); // Respawn the ball after a delay
        }
    }

    private void RespawnBall()
    {
        // Reset the ball's position and velocity
        transform.position = startPos;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true; // Disable physics affecting the ball
    }
}
