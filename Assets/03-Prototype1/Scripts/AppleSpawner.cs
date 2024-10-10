using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    public GameObject applePrefab;
    public float gridSize = 1f;
    public int gridWidth = 20;
    public int gridLength = 20;
    public float yPosition = 0.5f; // Height of the playing field

    void Start()
    {
        SpawnApple();
    }

    public void SpawnApple()
    {
        int x = Random.Range(-gridWidth / 2, gridWidth / 2);
        int z = Random.Range(-gridLength / 2, gridLength / 2);

        Vector3 position = new Vector3(x * gridSize, yPosition, z * gridSize);
        Instantiate(applePrefab, position, Quaternion.identity);
    }
}