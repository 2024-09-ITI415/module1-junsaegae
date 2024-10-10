using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class GameManager : MonoBehaviour
{
    public AppleSpawner appleSpawner;  // Reference to the AppleSpawner
    public SnakeController snakeController;  // Reference to the SnakeController
    public GameOverScreen gameOverScreen;  // Reference to the GameOverScreen
    private int score = 0;  // Initial score
    public TextMeshProUGUI scoreText;  // Use TextMeshProUGUI for score display

    void Start()
    {
        gameOverScreen.gameObject.SetActive(false); // Hide the game over screen at the start
        scoreText.gameObject.SetActive(true);
        UpdateScoreUI();  // Ensure the score is displayed at the start
        appleSpawner.SpawnSnakeApple(); // Spawn the first apple
    }

    public void IncrementScore()
    {
        score += 1;  // Increment score by 1
        UpdateScoreUI();  // Update displayed score
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();  // Update the score display
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over! Final Score: " + score);
        gameOverScreen.Setup(score); // Show the game over screen with the score
        Time.timeScale = 0; // Pause the game
    }

    public void RestartGame()
    {
        score = 0; // Reset score
        Time.timeScale = 1; // Resume normal time scale
        snakeController.transform.position = Vector3.zero; // Reset snake position

        // Clear the snake's tail
        foreach (Transform child in snakeController.transform)
        {
            Destroy(child.gameObject);
        }

        gameOverScreen.gameObject.SetActive(false); // Hide game over screen
        appleSpawner.SpawnSnakeApple(); // Respawn the apple
        UpdateScoreUI(); // Update the score display after restart
    }

    public int GetScore()
    {
        return score;  // Return the current score
    }
}
