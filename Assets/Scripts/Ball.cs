using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the ball collides with the player
        if (collision.CompareTag("Player"))
        {
            // If the ball collides with the player, call CollectBallBack() directly on the player GameObject
            PlayerController playerController = collision.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.CollectBallBack();
            }

            // Destroy the ball
            Destroy(gameObject);
        }
    }
}