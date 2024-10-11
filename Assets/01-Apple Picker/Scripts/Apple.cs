using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float bottomY = -20f;

    void Update()
    {
        if (transform.position.y < bottomY)
        {
            // Get the ApplePicker script attached to the main camera
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            Destroy(this.gameObject); // Destroy the apple GameObject
        }
    }
}
