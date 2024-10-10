using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    public GameObject snakeApplePrefab;  // Changed from applePrefab to snakeApplePrefab
    public float gridSize = 1f;
    public int gridWidth = 20;
    public int gridLength = 20;
    public float yPosition = 0.5f; // Height of the playing field

    void Start()
    {
        SpawnSnakeApple();  // Changed from SpawnApple to SpawnSnakeApple
    }

    public void SpawnSnakeApple()  // Changed from SpawnApple to SpawnSnakeApple
    {
        int x = Random.Range(-gridWidth / 2, gridWidth / 2);
        int z = Random.Range(-gridLength / 2, gridLength / 2);

        Vector3 position = new Vector3(x * gridSize, yPosition, z * gridSize);
        Instantiate(snakeApplePrefab, position, Quaternion.identity);
    }
}
