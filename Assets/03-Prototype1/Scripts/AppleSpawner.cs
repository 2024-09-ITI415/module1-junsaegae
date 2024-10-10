using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    public GameObject snakeApplePrefab; // Prefab for the snake apple
    public float gridSize = 1f;
    public int gridWidth = 20;
    public int gridLength = 20;
    public float yPosition = 0.5f; // Height of the playing field

    void Start()
    {
        SpawnSnakeApple(); // Spawn the initial apple
    }

    public void SpawnSnakeApple() // Method to spawn an apple
    {
        int x = Random.Range(-gridWidth / 2, gridWidth / 2);
        int z = Random.Range(-gridLength / 2, gridLength / 2);

        Vector3 position = new Vector3(x * gridSize, yPosition, z * gridSize);
        Instantiate(snakeApplePrefab, position, Quaternion.identity);
    }

    public void ClearApples() // Method to clear all apples
    {
        // Find all GameObjects tagged "SnakeApple" and destroy them
        GameObject[] apples = GameObject.FindGameObjectsWithTag("SnakeApple");
        foreach (GameObject apple in apples)
        {
            Destroy(apple);
        }
    }
}
