using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;

    private static int score = 0;

    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<Text>();
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
        scoreGT.text = score.ToString();
    }

    public static int GetScore()
    {
        return score;
    }
}