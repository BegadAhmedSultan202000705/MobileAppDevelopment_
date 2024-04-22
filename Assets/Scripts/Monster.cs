using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public float moveSpeed = 8f;

    // Declare a delegate for monster destruction
    public delegate void MonsterDestroyed();
    // Event to be invoked when the monster is destroyed
    public event MonsterDestroyed OnDestroyed;

    void Start() { }

    void Update()
    {
        // Move the monster to the right
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boundary")
        {
            // Reverse the move speed when hitting a boundary
            moveSpeed *= -1;
        }
        // Optionally, you can add more collision logic here, e.g., damage, interaction with other game objects
    }

    // Method to destroy the monster
    public void DestroyMonster()
    {
        // Invoke the OnDestroyed event before destroying the monster
        OnDestroyed?.Invoke();

        // Destroy the monster game object
        Destroy(gameObject);
    }
}
