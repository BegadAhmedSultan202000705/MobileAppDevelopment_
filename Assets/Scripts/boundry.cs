using UnityEngine;

public class Boundary : MonoBehaviour
{
    private Rigidbody2D rb;
    // This method is called when a collision with another 2D collider occurs
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