using System.Collections;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI; // The static point of interest

    [Header("Set in Inspector")]
    public float easing = 0.05f; // Easing factor for smooth camera follow
    public Vector2 minXY = Vector2.zero; // Minimum X and Y values for the camera position

    [Header("Set Dynamically")]
    public float camZ; // The desired Z position of the camera

    void Awake() {
        camZ = this.transform.position.z;
    }

    void FixedUpdate() {
        // Return if there's no POI (point of interest) to follow
        if (POI == null) return;

        // Get the position of the POI
        Vector3 destination = POI.transform.position;

        // Limit the X & Y values to the minimum values specified in minXY
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);

        // Interpolate from the current camera position toward the destination for smooth movement
        destination = Vector3.Lerp(transform.position, destination, easing);

        // Force destination.z to be camZ to keep the camera at a consistent distance
        destination.z = camZ;

        // Set the camera's position to the computed destination
        transform.position = destination;

        // Adjust the orthographicSize of the Camera to keep the ground in view
        Camera.main.orthographicSize = destination.y + 10; // Adjusts the view based on POI’s Y position
    }
}
