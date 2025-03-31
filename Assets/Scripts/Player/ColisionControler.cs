using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public float pushPower = 2.5f;
    // only for GameObjects with a character controller applied
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        // If no Rigidbody or is Kinematic, do nothing
        if (body == null || body.isKinematic)
        {
            return;
        }
        // Don't push ground or platform GameObjects below character
        if (hit.moveDirection.y < -0.3)
        {
            return;
        }
        // Calculate push direction from move direction, only along x and z axes - no vertical or y-axis pushing
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        // Apply the push power and pushing direction to the pushed object's velocity
        if (hit.gameObject.tag == "Object"&& Input.GetMouseButton(0))
        {
            body.velocity = pushDir * pushPower;
        }
    }
}