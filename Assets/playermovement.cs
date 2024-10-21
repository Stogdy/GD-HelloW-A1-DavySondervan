using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    public float moveSpeed = 5f;  // Speed of the character movement
    public float jumpForce = 7f;  // Force applied for jumping
    public float gravity = -9.81f;  // Gravity effect on the character
    public float groundCheckDistance = 0.4f;  // Distance to check for ground
    public LayerMask groundMask;  // Layer for ground detection

    private CharacterController controller;  // Reference to Unity's CharacterController component
    private Vector3 velocity;  // Stores the player's movement direction
    private bool isGrounded;  // To check if the character is on the ground

    public Transform groundCheck;  // Reference point for checking if grounded

    void Start()
    {
        // Get the CharacterController component attached to the GameObject
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Ground check: Create a small sphere below the player to check if grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckDistance, groundMask);

        // Reset velocity if the player is grounded
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;  // Small negative value to keep the character grounded
        }

        // Get input for movement
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Calculate movement direction based on input
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Move the character using the CharacterController
        controller.Move(move * moveSpeed * Time.deltaTime);

        // Jump: Check if the jump button is pressed and the character is grounded
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);  // Calculate jump velocity
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        // Apply the velocity (gravity and jump)
        controller.Move(velocity * Time.deltaTime);
    }
}
