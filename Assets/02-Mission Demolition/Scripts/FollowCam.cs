void FixedUpdate () {
    // If there is no POI, return to position [0, 0, 0]
    Vector3 destination;

    if (POI == null) {
        destination = Vector3.zero; // Return to default position [0, 0, 0]
    } else {
        // Get the position of the POI
        destination = POI.transform.position;

        // If the POI is a "Projectile", check if it's at rest
        if (POI.tag == "Projectile") {
            // If the Rigidbody is sleeping (not moving)
            if (POI.GetComponent<Rigidbody>().IsSleeping()) {
                // Stop following the POI
                POI = null;
                return; // In the next update, the camera will reset
            }
        }
    }

    // Limit the X & Y values to minimum values specified in minXY
    destination.x = Mathf.Max(minXY.x, destination.x);
    destination.y = Mathf.Max(minXY.y, destination.y);

    // Interpolate from the current camera position toward the destination for smooth movement
    destination = Vector3.Lerp(transform.position, destination, easing);

    // Force destination.z to be camZ to keep the camera at a consistent distance
    destination.z = camZ;

    // Set the camera's position to the computed destination
    transform.position = destination;

    // Adjust the orthographicSize of the Camera to keep the ground in view
    Camera.main.orthographicSize = destination.y + 10;
}
