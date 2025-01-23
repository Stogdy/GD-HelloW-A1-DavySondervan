using UnityEngine;

public class BreathingAnimation : MonoBehaviour
{
    // Speed of the breathing movement
    public float breathSpeed = 1.0f;

    // Distance of the up and down movement
    public float breathHeight = 0.1f;

    // Original starting position of the object
    private Vector3 originalPosition;

    void Start()
    {
        // Store the initial position to oscillate around it
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        // Calculate the new Y position for the breathing effect
        float newY = originalPosition.y + Mathf.Sin(Time.time * breathSpeed) * breathHeight;

        // Update the position of the player model
        transform.localPosition = new Vector3(originalPosition.x, newY, originalPosition.z);
    }
}