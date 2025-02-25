using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform player;         // Player transform to follow
    public float rotationSpeed = 5f; // Speed of camera rotation
    public float upperLimit = 30f;   // Upper limit of vertical rotation
    public float lowerLimit = -30f;  // Lower limit of vertical rotation
    public float distance = 5f;      // Distance from player
    public float smoothRotationSpeed = 10f; // Speed of smoothing for rotation
    public float smoothPositionSpeed = 0.125f; // Speed of smoothing for camera position
    public LayerMask collisionLayer; // Layer mask for objects that the camera should avoid (e.g., walls, floor, etc.)

    private float currentRotationX = 0f;
    private float currentRotationY = 0f;

    private Vector3 currentVelocity = Vector3.zero;

    // Update is called once per frame
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

        currentRotationX += mouseX;
        currentRotationY -= mouseY;

        // Clamp vertical rotation to avoid flipping
        currentRotationY = Mathf.Clamp(currentRotationY, lowerLimit, upperLimit);

        // Smoothly rotate the camera using Slerp for smooth rotation transitions
        Quaternion targetRotation = Quaternion.Euler(currentRotationY, currentRotationX, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * smoothRotationSpeed);

        // Calculate desired position behind the player
        Vector3 desiredPosition = player.position - transform.forward * distance;

        // Raycast to check if there are any obstacles between the player and the camera
        RaycastHit hit;
        if (Physics.Raycast(player.position, -transform.forward, out hit, distance, collisionLayer))
        {
            // If an obstacle is detected, position the camera at the hit point (slightly in front of the hit point to avoid clipping)
            desiredPosition = hit.point + transform.forward * 0.2f;
        }

        // Smoothly move the camera position using Lerp for smooth positional transitions
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref currentVelocity, smoothPositionSpeed);
    }
}