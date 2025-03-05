using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 4f;
    public float jumpHeight = 1.0f;  // Adjustable jump height
    public float gravityValue = -9.81f; // Gravity for the player
    public Transform cameraTransform; // Reference to the camera's transform for movement alignment

    private float jumpBufferTime = 0.1f; // Time (in seconds) to buffer the jump input after hitting the ground
    private float jumpBufferCounter = 0f;

    private void Start()
    {
        // You could initialize things here if needed
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;  // Reset vertical velocity when grounded
            jumpBufferCounter = jumpBufferTime; // Reset the jump buffer time when the player is grounded
        }

        // Allow jump if the buffer counter is active
        if (jumpBufferCounter > 0f)
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        // Get input for movement (WASD or Arrow keys)
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Calculate the direction relative to the camera's forward and right vectors
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Ensure the forward and right vectors are flattened on the x-z plane (ignore vertical component)
        forward.y = 0;
        right.y = 0;

        // Normalize the vectors to avoid diagonal speed boost
        forward.Normalize();
        right.Normalize();

        // Move relative to the camera's orientation
        Vector3 move = forward * moveZ + right * moveX;

        // Apply movement
        controller.Move(move * Time.deltaTime * playerSpeed);

        // Rotate the player to face the direction of movement
        if (move != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(move, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, 0.1f); // Adjust rotation speed here
        }

        // Handle jumping
        // Check if the player presses the jump button and is grounded
        if (Input.GetButtonDown("Jump") && groundedPlayer || jumpBufferCounter > 0f && Input.GetButtonDown("Jump"))
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);  // Apply jump force only when grounded
            jumpBufferCounter = 0f; // Reset buffer after jump
        }

        // Apply gravity to the player
        playerVelocity.y += gravityValue * Time.deltaTime;

        // Apply the vertical velocity (gravity or jump) to the movement
        controller.Move(playerVelocity * Time.deltaTime);
    }
}