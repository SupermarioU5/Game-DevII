using UnityEngine;
using System.Collections.Generic;

public class DoorOpener : MonoBehaviour
{
    public GameObject door; // The door object
    public float speed = 2f; // Speed at which the door opens
    public Transform startPos;
    private float close;
    private float openHeight;

    private HashSet<GameObject> objectsOnButton = new HashSet<GameObject>(); // Track all objects on the button

    private void Start()
    {
        close = startPos.position.y;
        openHeight = startPos.position.y + startPos.localScale.y - 0.5f;
    }

    void Update()
    {
        // If any object is on the button, move the door upwards
        if (objectsOnButton.Count > 0)
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
        // If the object that collided with the button is the box or player, add it to the list
        if (other.CompareTag("Object") || other.CompareTag("Player"))
        {
            if (this.CompareTag("Buttons"))
            {
                objectsOnButton.Add(other.gameObject); // Add object to the set
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // If the object that left the button is the box or player, remove it from the list
        if (other.CompareTag("Object") || other.CompareTag("Player"))
        {
            objectsOnButton.Remove(other.gameObject); // Remove object from the set
        }
    }
}