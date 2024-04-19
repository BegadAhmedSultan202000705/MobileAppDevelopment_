using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public float moveSpeed;

    void Start() { }


    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            if (collision.gameObject.tag == "Boundary")
            {
                moveSpeed *= -1;
            }
        }



    }

}
