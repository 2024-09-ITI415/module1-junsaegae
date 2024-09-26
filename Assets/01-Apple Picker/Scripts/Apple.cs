using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    
    public static float bottomY= -20f;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.y < bottomY) {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
