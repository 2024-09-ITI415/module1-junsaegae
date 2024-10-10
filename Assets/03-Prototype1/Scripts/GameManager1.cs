using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AppleSpawner appleSpawner;
    public SnakeController snakeController;
    public int score = 0;

    void Start()
    {
        // Initialize game
    }

    public void IncrementScore()
    {
        score++;
        appleSpawner.SpawnApple();
        // Update UI or perform other actions
    }

    public void GameOver()
    {
        // Handle game over logic
        Debug.Log("Game Over! Final Score: " + score);
        // You might want to restart the game or show a game over screen
    }
}