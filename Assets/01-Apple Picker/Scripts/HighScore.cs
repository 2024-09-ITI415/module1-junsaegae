using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public static int score = 1000;
    private Text highScoreText;

    void Awake()
    {
        // Load the high score from PlayerPrefs
        score = PlayerPrefs.GetInt("HighScore", 1000);
        
        // Get the Text component attached to this GameObject
        highScoreText = GetComponent<Text>();
        
        // Update the display
        UpdateHighScoreDisplay();
    }

    void Update()
    {
        // Check if the current score is higher than the stored high score
        if (Basket.GetScore() > score)
        {
            score = Basket.GetScore();
            PlayerPrefs.SetInt("HighScore", score);
            UpdateHighScoreDisplay();
        }
    }

    void UpdateHighScoreDisplay()
    {
        highScoreText.text = "High Score: " + score;
    }

    // Method to reset the high score (can be called from other scripts or a UI button)
    public void ResetHighScore()
    {
        score = 0;
        PlayerPrefs.SetInt("HighScore", score);
        UpdateHighScoreDisplay();
    }
}