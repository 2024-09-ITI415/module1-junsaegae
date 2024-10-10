using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    public GameObject snakeApplePrefab;  // Prefab for the snake apple
    public float gridSize = 1f;  // Size of the grid
    public int gridWidth = 20;   // Width of the grid
    public int gridLength = 20;  // Length of the grid
    public float yPosition = 0.5f; // Y position (height) where apples will spawn

    void Start()
    {
        SpawnSnakeApple();  // Spawn an apple when the game starts
    }

    public void SpawnSnakeApple()
    {
        // Randomly select a position within the grid bounds
        int x = Random.Range(-gridWidth / 2, gridWidth / 2);
        int z = Random.Range(-gridLength / 2, gridLength / 2);

        // Create a position vector at the specified height (yPosition)
        Vector3 position = new Vector3(x * gridSize, yPosition, z * gridSize);
        
        // Instantiate the apple prefab at the random position
        Instantiate(snakeApplePrefab, position, Quaternion.identity);
    }
}
