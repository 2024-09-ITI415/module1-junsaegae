using UnityEngine;
using TMPro; // For TextMeshPro
using UnityEngine.UI; // For Button

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Updated to use TextMeshProUGUI
    public Button restartButton;

    private void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
        gameObject.SetActive(false); // Ensure it starts hidden
    }

    public void Setup(int score)
    {
        gameObject.SetActive(true); // Show the game over screen

        if (scoreText != null) // Check if scoreText is assigned
        {
            scoreText.text = "Score: " + score.ToString(); // Update the score display
        }
        else
        {
            Debug.LogError("scoreText is not assigned in GameOverScreen."); // Log error if not assigned
        }
    }

    void RestartGame()
    {
        FindObjectOfType<GameManager>().RestartGame(); // Call RestartGame in GameManager
    }
}
