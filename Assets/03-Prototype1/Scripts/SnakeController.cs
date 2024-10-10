using UnityEngine;
using System.Collections.Generic;

public class SnakeController : MonoBehaviour
{
    public float moveSpeed = 20f; // Speed of the snake
    public float gridSize = 0.5f; // Size of the grid
    public GameObject tailPrefab; // Prefab for the tail

    private Vector3 direction = Vector3.forward; // Current direction of movement
    private List<Transform> tail = new List<Transform>(); // List to store tail segments
    private bool ate = false; // Flag for eating an apple
    private bool canEat = true; // Flag to prevent multiple increments
    private GameManager gameManager; // Reference to the GameManager

    void Start()
    {
        // Move the snake every 0.1 seconds
        InvokeRepeating("Move", 0f, 0.1f);
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        // Handle input
        if (Input.GetKeyDown(KeyCode.W) && direction != Vector3.back)
            direction = Vector3.forward;
        else if (Input.GetKeyDown(KeyCode.S) && direction != Vector3.forward)
            direction = Vector3.back;
        else if (Input.GetKeyDown(KeyCode.A) && direction != Vector3.right)
            direction = Vector3.left;
        else if (Input.GetKeyDown(KeyCode.D) && direction != Vector3.left)
            direction = Vector3.right;
    }

    void Move()
    {
        Vector3 v = transform.position;

        // Create a new tail segment if the snake ate an apple
        if (ate)
        {
            GameObject g = Instantiate(tailPrefab, v, Quaternion.identity);
            tail.Insert(0, g.transform);
            ate = false; // Reset the ate flag
            canEat = true; // Reset the canEat flag
        }
        // Move tail
        else if (tail.Count > 0)
        {
            tail[tail.Count - 1].position = v;
            tail.Insert(0, tail[tail.Count - 1]);
            tail.RemoveAt(tail.Count - 1);
        }

        // Move head
        transform.Translate(direction * gridSize);
    }

    void OnTriggerEnter(Collider other)
    {
        // If the snake collides with an apple
        if (other.CompareTag("SnakeApple") && canEat)
        {
            ate = true; // Snake ate an apple, so it will grow
            Destroy(other.gameObject); // Destroy the eaten apple

            // Spawn a new apple
            FindObjectOfType<AppleSpawner>().SpawnSnakeApple();

            // Increment score and update the display
            gameManager.IncrementScore();
            canEat = false; // Prevent multiple increments
        }
        else if (other.CompareTag("Wall") || other.CompareTag("Tail"))
        {
            gameManager.GameOver(); // Trigger game over
        }
    }
}
