using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour 
{
    // Fields set in the Unity Inspector pane
    [Header("Set in Inspector")]
    public GameObject prefabProjectile;   // a
    public float velocityMult = 8f;       // a

    // Fields set dynamically
    [Header("Set Dynamically")]
    public GameObject launchPoint;        // b
    public Vector3 launchPos;             // b
    public GameObject projectile;         // b
    public bool aimingMode;               // b

    private Rigidbody projectileRigidbody; // a

    // Static reference to the Slingshot instance
    static private Slingshot S;            // Singleton reference

    // Static property for LAUNCH_POS, to be accessed by other scripts
    static public Vector3 LAUNCH_POS 
    {
        get 
        {
            if (S == null) return Vector3.zero; // Return Vector3.zero if the singleton is not initialized
            return S.launchPos; // Return the launch position
        }
    }

    void Awake() 
    {
        // Set the singleton instance
        S = this;

        // Find the launch point in the hierarchy and initialize it
        Transform launchPointTrans = transform.Find("LaunchPoint");
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);
        launchPos = launchPointTrans.position; // Initialize launchPos with the launchPoint's position
    }

    void OnMouseEnter() 
    {
        // Activate the launch point when the mouse hovers over the Slingshot
        launchPoint.SetActive(true);
    }

    void OnMouseExit() 
    {
        // Deactivate the launch point when the mouse leaves the Slingshot area
        launchPoint.SetActive(false);
    }

    void OnMouseDown() 
    {
        // The player has pressed the mouse button while over the Slingshot
        aimingMode = true;

        // Instantiate a new projectile
        projectile = Instantiate(prefabProjectile) as GameObject;
        // Position the projectile at the launch position
        projectile.transform.position = launchPos;

        // Set the projectile to be kinematic while aiming
        projectileRigidbody = projectile.GetComponent<Rigidbody>();
        projectileRigidbody.isKinematic = true;
    }

    void Update() 
    {
        // If Slingshot is not in aimingMode, don’t run the following code
        if (!aimingMode) return;

        // Get the current mouse position in 2D screen coordinates
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // Find the delta (distance) between the launch position and the mouse position
        Vector3 mouseDelta = mousePos3D - launchPos;

        // Limit the mouseDelta to the radius of the Slingshot's SphereCollider
        float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if (mouseDelta.magnitude > maxMagnitude) 
        {
            mouseDelta.Normalize(); // Normalize the vector to limit its magnitude
            mouseDelta *= maxMagnitude; // Scale it to the maximum magnitude
        }

        // Move the projectile to the new position
        Vector3 projPos = launchPos + mouseDelta;
        projectile.transform.position = projPos;

        if (Input.GetMouseButtonUp(0)) 
        {
            // When the mouse button is released, stop aiming
            aimingMode = false;
            projectileRigidbody.isKinematic = false; // Disable kinematic mode to allow physics to take over
            projectileRigidbody.velocity = -mouseDelta * velocityMult; // Set the projectile velocity

            projectile = null; // Clear the reference to the projectile
            MissionDemolition.ShotFired();
            ProjectileLine.S.poi = projectile;
        }
    }
}
