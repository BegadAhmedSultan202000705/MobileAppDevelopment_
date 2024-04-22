using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the ball collides with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // If the ball collides with the player, call CollectBallBack() directly on the player GameObject
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.CollectBallBack();
            }

            // Destroy the ball
            Destroy(gameObject);
        }
    }
}