using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    public GameObject snakeApplePrefab; // Prefab for the snake apple
    public float gridSize = 1f;
    public int gridWidth = 20;
    public int gridLength = 20;
    public float yPosition = 0.5f; // Height of the playing field

    private GameObject currentApple; // Store the currently active apple

    void Start()
    {
        SpawnSnakeApple(); // Spawn the initial apple
    }

    public void SpawnSnakeApple() // Method to spawn an apple
    {
        // Clear existing apple
        ClearApples();

        // Generate new apple position
        int x = Random.Range(-gridWidth / 2, gridWidth / 2);
        int z = Random.Range(-gridLength / 2, gridLength / 2);

        Vector3 position = new Vector3(x * gridSize, yPosition, z * gridSize);
        currentApple = Instantiate(snakeApplePrefab, position, Quaternion.identity); // Spawn new apple
    }

    public void ClearApples() // Method to clear existing apple
    {
        if (currentApple != null)
        {
            Destroy(currentApple); // Destroy the existing apple
            currentApple = null; // Clear reference
        }
    }
}
