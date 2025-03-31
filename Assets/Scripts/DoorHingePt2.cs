using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorHingeP2 : MonoBehaviour
{
    public float openAngle = -90f; // The angle to rotate the door to open (in degrees)
    public float rotationSpeed = 2f; // Speed at which the door rotates
    public DoorRotate og;
    public GameObject beyond;
    public GameObject locks;

    private bool opening = false; // To track if the door is opening
    private Quaternion closedRotation; // The initial rotation of the door
    private Quaternion openRotation; // The target rotation of the door

    void Start()
    {
        closedRotation = transform.rotation; // Set the initial rotation as closed
        openRotation = Quaternion.Euler(closedRotation.eulerAngles.x, closedRotation.eulerAngles.y + openAngle, closedRotation.eulerAngles.z); // Calculate the open rotation
    }
    void Update()
    {
        opening = og.isOpening;
        // If the door is opening
        if (opening)
        {
            Destroy(locks);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, openRotation, rotationSpeed * Time.deltaTime);

            if (Quaternion.Angle(transform.rotation, openRotation) < 1f)
            {
                opening = false;
                Destroy(beyond);
            }
        }
    }
}
