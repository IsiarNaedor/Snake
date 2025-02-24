// using System.Collections.Generic;
// using UnityEngine;

// public class SnakeBody : MonoBehaviour
// {
//     public float moveSpeed = 0.2f;
//     private Vector2 direction = Vector2.right;
//     private List<Transform> snakeBody = new List<Transform>();
//     public GameObject bodyPrefab;

//     void Start()
//     {
//         // InvokeRepeating(nameof(Move), moveSpeed, moveSpeed);
//         Debug.Log("Spawned body part at: " + bodyPart.transform.position);
//     }

//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.W) && direction != Vector2.down)
//             direction = Vector2.up;
//         else if (Input.GetKeyDown(KeyCode.S) && direction != Vector2.up)
//             direction = Vector2.down;
//         else if (Input.GetKeyDown(KeyCode.A) && direction != Vector2.right)
//             direction = Vector2.left;
//         else if (Input.GetKeyDown(KeyCode.D) && direction != Vector2.left)
//             direction = Vector2.right;
//     }

//     void Move()
//     {
//         Vector2 newPosition = (Vector2)transform.position + direction;

//         // Move the body segments
//         for (int i = snakeBody.Count - 1; i > 0; i--)
//         {
//             snakeBody[i].position = snakeBody[i - 1].position;
//         }
//         if (snakeBody.Count > 0)
//             snakeBody[0].position = transform.position;

//         transform.position = newPosition;
//     }

//     public void Grow(){
//         Debug.Log("Growing snake! Current length: " + snakeBody.Count);
//         GameObject bodyPart = Instantiate(bodyPrefab, transform.position, Quaternion.identity);
//         snakeBody.Add(bodyPart.transform);
//     }

//     void OnTriggerEnter2D(Collider2D other)
//     {
//         Debug.Log("Collision with: " + other.gameObject.name);
//         if (other.CompareTag("Apple"))
//         {
//             Grow();
//             Destroy(other.gameObject);
//         }
//     }
// }
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    public float moveSpeed = 0.2f;
    private Vector2 direction = Vector2.right;
    public List<Transform> snakeBody = new List<Transform>();
    public GameObject bodyPrefab;

    void Start()
    {
        // Automatically move snake
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

        // Move body segments
        for (int i = snakeBody.Count - 1; i > 0; i--)
        {
            snakeBody[i].position = snakeBody[i - 1].position;
        }

        // First body part follows head
        if (snakeBody.Count > 0)
            snakeBody[0].position = transform.position;

        // Move head
        transform.position = newPosition;
    }

    public void Grow()
    {
        Debug.Log("Growing snake! Current length: " + snakeBody.Count);

        // Reposition body part
        Vector3 spawnPosition = snakeBody.Count > 0 ? snakeBody[snakeBody.Count - 1].position : transform.position;

        // Instantiate the new body part
        GameObject bodyPart = Instantiate(bodyPrefab, spawnPosition, Quaternion.identity);

        // Add the new body part 
        snakeBody.Add(bodyPart.transform);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision with: " + other.gameObject.name);
        if (other.CompareTag("Apple"))
        {
            Grow();
            Destroy(other.gameObject);
        }
    }
}