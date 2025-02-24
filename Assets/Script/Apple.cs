// // // using UnityEngine;
// // // using System.Collections.Generic; 

// // // public class Apple : MonoBehaviour{
// // //     public BoxCollider2D gridArea;  // Assign the game area in Inspector

// // //     void Start(){
// // //         RandomizePosition();
// // //     }

// // //     void RandomizePosition(){
// // //         Bounds bounds = gridArea.bounds;
// // //         Vector2 newPosition;

// // //         do{
// // //             newPosition = new Vector2(
// // //                 Mathf.Round(Random.Range(bounds.min.x, bounds.max.x)),
// // //                 Mathf.Round(Random.Range(bounds.min.y, bounds.max.y))
// // //             );

// // //         } 
// // //         while (IsSnakePosition(newPosition)); 

// // //         transform.position = newPosition;
// // //     }

// // //     bool IsSnakePosition(Vector2 position){
// // //         foreach (Transform bodyPart in FindObjectOfType<SnakeBody >().snakeBody){
// // //             if ((Vector2)bodyPart.position == position)
// // //                 return true;
// // //         }
// // //         return false;
// // //     }

// // //     void OnTriggerEnter2D(Collider2D other){
// // //         if (other.CompareTag("SnakeBody")){
// // //             Destroy(gameObject);
// // //             Instantiate(this, Vector2.zero, Quaternion.identity).RandomizePosition();
// // //         }
// // //     }
// // // }
// using UnityEngine;
// using System.Collections.Generic;

// public class Apple : MonoBehaviour
// {
//     public BoxCollider2D gridArea; // Assign the game area in Inspector

//     void Start()
//     {
//         RandomizePosition();
//     }

//     void RandomizePosition()
//     {
//         Bounds bounds = gridArea.bounds;
//         Vector2 newPosition;
//         int maxAttempts = 100; // Prevent infinite loop
//         int attempts = 0;

//         do
//         {
//             newPosition = new Vector2(
//                 Mathf.Round(Random.Range(bounds.min.x, bounds.max.x)),
//                 Mathf.Round(Random.Range(bounds.min.y, bounds.max.y))
//             );

//             attempts++;
//             if (attempts > maxAttempts)
//             {
//                 Debug.LogWarning("Failed to find a valid position for Apple!");
//                 return;
//             }

//         } while (IsSnakePosition(newPosition));

//         transform.position = newPosition;
//     }

//     bool IsSnakePosition(Vector2 position)
//     {
//         SnakeBody snake = FindObjectOfType<SnakeBody>(); // Cache reference
//         if (snake == null) return false;

//         foreach (Transform bodyPart in snake.snakeBody) // Use a property to access snakeBody
//         {
//             if ((Vector2)bodyPart.position == position)
//                 return true;
//         }
//         return false;
//     }

//     void OnTriggerEnter2D(Collider2D other)
//     {
//         if (other.CompareTag("SnakeBody"))
//         {
//             Destroy(gameObject);
//             Apple newApple = Instantiate(this, Vector2.zero, Quaternion.identity);
//             newApple.RandomizePosition(); // Call on the new instance
//         }
//     }
// }