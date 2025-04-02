using UnityEngine;

public class DoorRotate : MonoBehaviour
{
    public float openAngle = 90f; // The angle to rotate the door to open (in degrees)
    public float rotationSpeed = 2f; // Speed at which the door rotates
    public TKeyCollecter Tkey;
    public AudioSource doorOpen;

    public bool isOpening = false; // To track if the door is opening
    private bool keyGet;
    private Quaternion closedRotation; // The initial rotation of the door
    private Quaternion openRotation; // The target rotation of the door

    void Start()
    {
        closedRotation = transform.rotation; // Set the initial rotation as closed
        openRotation = Quaternion.Euler(closedRotation.eulerAngles.x, closedRotation.eulerAngles.y + openAngle, closedRotation.eulerAngles.z); // Calculate the open rotation
    }

    void Update()
    {
        if (Tkey.triangleKeyGet)
        {
            keyGet = true;
        }
        // If the door is opening
        if (isOpening)
        {
            doorOpen.Play();
            transform.rotation = Quaternion.RotateTowards(transform.rotation, openRotation, rotationSpeed * Time.deltaTime);

            if (Quaternion.Angle(transform.rotation, openRotation) < 1f)
            {
                isOpening = false;
            }
        }
    }
    // Method to trigger the door to open
    public void OpenDoor()
    {
        if (!isOpening && keyGet)
        {
            isOpening = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OpenDoor(); // Call the OpenDoor method when the player is near
        }
    }
}