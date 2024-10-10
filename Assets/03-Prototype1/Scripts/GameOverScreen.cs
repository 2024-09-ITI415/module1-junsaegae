using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text scoreText;
    public Button restartButton;

    private void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
    }

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        scoreText.text = "Score: " + score.ToString();
    }

    void RestartGame()
    {
        FindObjectOfType<GameManager>().RestartGame();
    }
}