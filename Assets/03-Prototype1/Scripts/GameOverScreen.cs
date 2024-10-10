using UnityEngine;
using TMPro; // Import TextMeshPro namespace
using UnityEngine.UI; // Import UnityEngine.UI namespace for Button

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI gameOverText; // Reference to Game Over Text
    public TextMeshProUGUI scoreText;     // Reference to Score Text
    public Button restartButton;           // Reference to Restart Button

    private void Start()
    {
        restartButton.onClick.AddListener(RestartGame); // Set up the restart button listener
        gameObject.SetActive(false); // Hide the game over screen at the start
    }

    // Setup method to display game over screen and score
    public void Setup(int score)
    {
        gameObject.SetActive(true); // Show the game over screen
        gameOverText.text = "Game Over"; // Set Game Over text
        scoreText.text = "Score: " + score.ToString(); // Display the score
    }

    // Method to handle restart
    void RestartGame()
    {
        FindObjectOfType<GameManager>().RestartGame(); // Call RestartGame in GameManager
    }
}
