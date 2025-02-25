using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHover : MonoBehaviour
{
    public bool rotate;  // Should it rotate?
    public float rotationSpeed = 50.0f;  // Speed of rotation
    public float hoverSpeed = 0.5f;  // Up and down hover speed
    public float hoverDistance = 0.8f;  // Distance hovering travels
    public Transform origin;  // The origin around which the object will rotate

    // Declare variable to store the new Vector3 used to change y-axis position in Update() function
    public Vector3 cubePos;

    // Declare variable that will be used to store the y-axis starting position in Start() function
    private float cubeY;

    // Start is called before the first frame update
    void Start()
    {
        cubeY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Use Sin function for smoother hovering movement
        float y = Mathf.Sin(Time.time * hoverSpeed) * hoverDistance + cubeY;

        // Set cubePos to a new Vector3 position -> x- and z-axis positions uses the current position of the GameObject
        cubePos = new Vector3(transform.position.x, y, transform.position.z);

        // Update the cube GameObject's position based on the new Vector3
        transform.position = cubePos;

        // Rotate around the origin if rotate is true
        if (rotate && origin != null)
        {
            // Rotate the object around the origin at the specified speed
            transform.RotateAround(origin.position, Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}