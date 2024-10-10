using UnityEngine;
using System.Collections.Generic;

public class SnakeController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float gridSize = 1f;
    public GameObject tailPrefab;

    private Vector3 direction = Vector3.forward;
    private List<Transform> tail = new List<Transform>();
    private bool ate = false;

    void Start()
    {
        InvokeRepeating("Move", 0f, 0.1f);
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
            ate = false;
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
        if (other.CompareTag("SnakeApple"))  // Changed from "Apple" to "SnakeApple"
        {
            ate = true;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Wall") || other.CompareTag("Tail"))
        {
            // Game over logic here
            Debug.Log("Game Over");
        }
    }
}