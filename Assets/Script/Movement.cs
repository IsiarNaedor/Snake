using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public float moveSpeed = 0.2f;
    private Vector2 direction = Vector2.right;
    private List<Transform> snakeBody = new List<Transform>();
    public GameObject bodyPrefab;

    void Start()
    {
        InvokeRepeating(nameof(Move), moveSpeed, moveSpeed);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && direction != Vector2.down)
            direction = Vector2.up;
        else if (Input.GetKeyDown(KeyCode.S) && direction != Vector2.up)
            direction = Vector2.down;
        else if (Input.GetKeyDown(KeyCode.A) && direction != Vector2.right)
            direction = Vector2.left;
        else if (Input.GetKeyDown(KeyCode.D) && direction != Vector2.left)
            direction = Vector2.right;
    }

    void Move()
    {
        Vector2 newPosition = (Vector2)transform.position + direction;

        // Move the body segments
        for (int i = snakeBody.Count - 1; i > 0; i--)
        {
            snakeBody[i].position = snakeBody[i - 1].position;
        }
        if (snakeBody.Count > 0)
            snakeBody[0].position = transform.position;

        transform.position = newPosition;
    }

    public void Grow()
    {
        GameObject bodyPart = Instantiate(bodyPrefab, transform.position, Quaternion.identity);
        snakeBody.Add(bodyPart.transform);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
        {
            Grow();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Wall") || other.CompareTag("Body"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
