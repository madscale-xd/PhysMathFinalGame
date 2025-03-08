using UnityEngine;

public class GearDetector : MonoBehaviour
{
    public float detectionRange = 5f; // Max distance the raycast can detect gears
    private Camera playerCamera; // Reference to the player's camera

    void Start()
    {
        // Find the main camera (assumes it's attached to the player's head)
        playerCamera = Camera.main;

        if (playerCamera == null)
        {
            Debug.LogError("Main Camera not found! Ensure your camera is tagged as 'MainCamera'.");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left-click
        {
            Debug.Log("LMB PRESSED");
            DetectGear();
        }
    }

    void DetectGear()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, detectionRange))
        {
            if (hit.collider.CompareTag("Gear"))
            {
                Debug.Log("GEAR HIT!");
            }
        }
    }
}
