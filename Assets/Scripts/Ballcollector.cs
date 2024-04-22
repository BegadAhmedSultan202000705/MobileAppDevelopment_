using UnityEngine;

public class BallCollector : MonoBehaviour
{
    // This method is called when the player collides with another object (not a trigger collider)
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is the ball by comparing the tag (or another unique identifier)
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Destroy the ball GameObject
            Destroy(collision.gameObject);
        }
    }
}
