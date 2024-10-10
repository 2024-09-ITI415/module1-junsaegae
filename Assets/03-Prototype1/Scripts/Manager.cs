using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AppleSpawner appleSpawner;
    public SnakeController snakeController;
    private int score = 0;  // Changed to private

    void Start()
    {
        // Initialize game
    }

    public void IncrementScore()
    {
        score++;
        appleSpawner.SpawnSnakeApple();
        // Update UI or perform other actions
        Debug.Log("Score: " + score);
    }

    public void GameOver()
    {
        // Handle game over logic
        Debug.Log("Game Over! Final Score: " + score);
        // You might want to restart the game or show a game over screen
    }

    // Getter for score if needed
    public int GetScore()
    {
        return score;
    }
}
