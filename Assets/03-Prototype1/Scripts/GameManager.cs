using UnityEngine;
using TMPro; // Import TextMeshPro package

public class GameManager : MonoBehaviour
{
    public AppleSpawner appleSpawner; // Reference to the AppleSpawner
    public SnakeController snakeController; // Reference to the SnakeController
    public GameOverScreen gameOverScreen; // Reference to the GameOverScreen
    private int score = 0;
    public TextMeshProUGUI scoreText; // Use TextMeshProUGUI for score display

    void Start()
    {
        gameOverScreen.gameObject.SetActive(false); // Ensure the game over screen is hidden
        UpdateScoreUI(); // Display initial score
    }

    public void IncrementScore()
    {
        score += 1; // Increment score by 1
        UpdateScoreUI(); // Update the displayed score
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString(); // Update score display
        }
        else
        {
            Debug.LogError("Score Text is not assigned in GameManager."); // Log error if scoreText is not assigned
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over! Final Score: " + score);
        gameOverScreen.Setup(score); // Set up the game over screen
        Time.timeScale = 0; // Pause the game
    }

    public void RestartGame()
    {
        score = 0; // Reset score
        Time.timeScale = 1; // Resume normal time scale
        snakeController.transform.position = Vector3.zero; // Reset snake position
        foreach (Transform child in snakeController.transform)
        {
            Destroy(child.gameObject); // Clear tail
        }
        gameOverScreen.gameObject.SetActive(false); // Hide game over screen
        appleSpawner.ClearApples(); // Clear all existing apples
        appleSpawner.SpawnSnakeApple(); // Respawn a new apple
        UpdateScoreUI(); // Update score display after restart
    }

    public int GetScore()
    {
        return score;
    }
}
