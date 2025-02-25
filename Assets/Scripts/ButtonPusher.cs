using UnityEngine;

public class ButtonPusher : MonoBehaviour
{
    // This function will be called when another collider enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that collided has the "Object" tag
        if (other.CompareTag("Object"))
        {
            // Check if the collided object has the "Buttons" tag
            if (this.CompareTag("Buttons"))
            {
                // Trigger the button action
                Debug.Log("Button has been pushed by the box!");

                // Add any actions you want to perform when the button is pressed.
                // For example, you could disable a UI element, play a sound, etc.
            }
        }
    }
}