using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add this namespace to use TextMeshPro

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public TextMeshProUGUI scoreGT; // Use TextMeshProUGUI instead of Text

    private static int score = 0;

    void Start()
    {
        // Find the GameObject with the name "ScoreCounter"
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        if (scoreGO != null)
        {
            // Get the TextMeshProUGUI component from the GameObject
            scoreGT = scoreGO.GetComponent<TextMeshProUGUI>();
            if (scoreGT == null)
            {
                Debug.LogError("No TextMeshProUGUI component found on ScoreCounter!");
            }
        }
        else
        {
            Debug.LogError("GameObject 'ScoreCounter' not found!");
        }

        score = 0;
        UpdateScore();
    }

    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);
            score += 100;
            UpdateScore();
        }
    }

    void UpdateScore()
    {
        if (scoreGT != null)
        {
            scoreGT.text = score.ToString(); // Update the TextMeshPro text
        }
        else
        {
            Debug.LogError("scoreGT is not set in UpdateScore!");
        }
    }

    public static int GetScore()
    {
        return score;
    }
}
