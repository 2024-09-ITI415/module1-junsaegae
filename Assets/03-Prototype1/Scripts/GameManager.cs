using UnityEngine;
using TMPro; // TextMesh Pro support

public class GameManager : MonoBehaviour
{
    public AppleSpawner appleSpawner;     // Reference to the AppleSpawner
    public SnakeController snakeController; // Reference to the SnakeController
    public GameOverScreen gameOverScreen; // Reference to the GameOverScreen
    public TextMeshProUGUI scoreText;      // Text element for the score display

    private int score = 0; // Initial score

    void Start()
    {
        // Initialize game
        gameOverScreen.gameObject.SetActive(false); // Hide game over screen initially
        UpdateScoreUI(); // Display initial score
    }

    // Called when the snake eats an apple
    public void IncrementScore()
    {
        score += 1; // Increment score by 1
        UpdateScoreUI(); // Update displayed score
    }

    // Updates the score UI in the game
    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString(); // Display current score
        }
    }

    // Handle Game Over logic
    public void GameOver()
    {
        Debug.Log("Game Over! Final Score: " + score);
        gameOverScreen.Setup(score); // Display game over screen with score
        Time.timeScale = 0; // Pause the game
    }

    // Restart the game
    public void RestartGame()
    {
        score = 0; // Reset score
        Time.timeScale = 1; // Resume normal time scale
        snakeController.transform.position = Vector3.zero; // Reset snake position

        // Clear tail
        foreach (Transform child in snakeController.transform)
        {
            Destroy(child.gameObject); // Destroy all tail segments
        }

        gameOverScreen.gameObject.SetActive(false); // Hide game over screen
        appleSpawner.SpawnSnakeApple(); // Respawn apple
    }

    // Getter for score
    public int GetScore()
    {
        return score; // Return current score
    }
}
