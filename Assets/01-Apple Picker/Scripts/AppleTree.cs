using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Set in Inspector")]

    public GameObject applePrefab;

    public float speed = 10f;

    public float leftAndRightEdge = 10f;

    public float chanceToChangeDirection = 0.1f;

    public float secondBetweenAppleDrop = 1f;
    void Start()
    {
        Invoke("DropApple", 2f);
    }

    void DropApple() {
        GameObject apple = Instantiate<GameObject;
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenApple)
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge) {
            speed = Mathf.Abs(speed);
        } else if (pos.x > leftAndRightEdge) {
            speed = -Mathf.Abs(speed);
        } else if (Random.value < chanceToChangeDirection) {
            speed *= -1;
        }
    }
    void FixedUpdate() {
        if (Random.value < chanceToChangeDirection) {
            speed *= -1;
        }
    }
}
