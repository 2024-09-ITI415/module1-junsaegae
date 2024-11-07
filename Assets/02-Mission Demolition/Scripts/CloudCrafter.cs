using UnityEngine;
using System.Collections;

public class CloudCrafter : MonoBehaviour {
    [Header("Set in Inspector")]
    public int numClouds = 40;                // Number of clouds to create
    public GameObject cloudPrefab;            // Prefab for each cloud instance
    public Vector3 cloudPosMin = new Vector3(-50, -5, 10); // Minimum position for clouds
    public Vector3 cloudPosMax = new Vector3(150, 100, 10); // Maximum position for clouds
    public float cloudScaleMin = 1;           // Minimum scale of each cloud
    public float cloudScaleMax = 3;           // Maximum scale of each cloud
    public float cloudSpeedMult = 0.5f;       // Multiplier for cloud movement speed

    private GameObject[] cloudInstances;      // Array to store references to cloud instances

    void Awake() {
        // Initialize the array to hold all cloud instances
        cloudInstances = new GameObject[numClouds];

        // Find the parent GameObject that will hold all the cloud instances
        GameObject anchor = GameObject.Find("CloudAnchor");

        // Create and position each cloud
        for (int i = 0; i < numClouds; i++) {
            // Instantiate a new cloud from the prefab
            GameObject cloud = Instantiate<GameObject>(cloudPrefab);

            // Set random position for the cloud within specified limits
            Vector3 cPos = Vector3.zero;
            cPos.x = Random.Range(cloudPosMin.x, cloudPosMax.x);
            cPos.y = Random.Range(cloudPosMin.y, cloudPosMax.y);

            // Randomly scale the cloud within the specified range
            float scaleU = Random.value;  // A random value between 0 and 1
            float scaleVal = Mathf.Lerp(cloudScaleMin, cloudScaleMax, scaleU);

            // Adjust Y position based on scale, so smaller clouds are closer to the ground
            cPos.y = Mathf.Lerp(cloudPosMin.y, cPos.y, scaleU);
            // Adjust Z position so smaller clouds are further away
            cPos.z = 100 - 90 * scaleU;

            // Apply position and scale to the cloud
            cloud.transform.position = cPos;
            cloud.transform.localScale = Vector3.one * scaleVal;

            // Set the cloud as a child of the anchor GameObject
            cloud.transform.SetParent(anchor.transform);

            // Store the cloud instance in the array for later use
            cloudInstances[i] = cloud;
        }
    }

    void Update() {
        // Loop through each cloud instance to update its position
        foreach (GameObject cloud in cloudInstances) {
            // Get the cloud's scale and current position
            float scaleVal = cloud.transform.localScale.x;
            Vector3 cPos = cloud.transform.position;

            // Move the cloud leftward; larger clouds move faster
            cPos.x -= scaleVal * Time.deltaTime * cloudSpeedMult;

            // If the cloud moves past the minimum X position, reset it to the right
            if (cPos.x <= cloudPosMin.x) {
                cPos.x = cloudPosMax.x;
            }

            // Apply the updated position to the cloud
            cloud.transform.position = cPos;
        }
    }
}
