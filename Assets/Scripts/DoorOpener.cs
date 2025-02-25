using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public GameObject door; // The door object
    public float speed = 2f; // Speed at which the door opens
    public Transform startPos;
    private float close;
    private float openHeight;

    private bool isOnButton = false;
    private void Start()
    {
        close = startPos.position.y;
        openHeight= startPos.position.y + startPos.localScale.y -.5f;
    }

    void Update()
    {
        // If the box is on the button, move the door upwards
        if (isOnButton)
        {
            // Move the door up over time to simulate opening
            door.transform.position = Vector3.Lerp(door.transform.position, new Vector3(door.transform.position.x, openHeight, door.transform.position.z), Time.deltaTime * speed);
        }
        else
        {
            door.transform.position = Vector3.Lerp(door.transform.position, new Vector3(door.transform.position.x, close, door.transform.position.z), Time.deltaTime * speed);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that collided with the button is the box
        if (other.CompareTag("Object"))
        {
            // Check if the button is the one the script is attached to
            if (this.CompareTag("Buttons"))
            {
                isOnButton = true; // Set flag to true when box is on button
                Debug.Log("Box is on the button, door is opening!");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            isOnButton = false;
        }
    }  
}