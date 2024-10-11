using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public AppleSpawner appleSpawner;
    public SnakeController snakeController;
    public TextMeshProUGUI scoreText;
    public GameOverScreen gameOverScreen;
    private int score = 0;

    void Start()
    {
        // Initialize game
        gameOverScreen.gameObject.SetActive(false);
    }

    public void IncrementScore()
    {
        score++;
        appleSpawner.SpawnSnakeApple();
        scoreText.text = ("Score: " + score);
        // Update UI or perform other actions
        Debug.Log("Score: " + score);
    }

    public void GameOver()
    {
        // Handle game over logic
        Debug.Log("Game Over! Final Score: " + score);
        gameOverScreen.Setup(score);
        Time.timeScale = 0; // Pause the game
    }

    public void RestartGame()
    {
        score = 0;
        Time.timeScale = 1; // Resume normal time scale
        // Reset snake
        snakeController.ResetSnake();
        // Hide game over screen
        gameOverScreen.gameObject.SetActive(false);
        // Respawn apple
        appleSpawner.SpawnSnakeApple();
    }

    public int GetScore()
    {
        return score;
    }
}
