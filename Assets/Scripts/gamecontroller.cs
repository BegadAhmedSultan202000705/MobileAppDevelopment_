using UnityEngine;

public class GameController : MonoBehaviour
{
    private int score = 0;

    // Method to increase the score
    public void IncreaseScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score); // You can remove or replace this with your own score tracking logic
    }
}
