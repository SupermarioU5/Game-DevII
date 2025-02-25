using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public float pushPower = 2.0f;
    // Let's you change the color of an object upon collision
    public bool changeColor;
    public Color myColor;

    // States of GameObjects to destroy them upon collision
    public bool destroyEnemy;
    public bool destroyCollectibles;

    // Allows you to add an audio file that's played on collision
    public AudioClip collisionAudio;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision other)
    {
        if (changeColor)
        {
            gameObject.GetComponent<Renderer>().material.color = myColor;
        }
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(collisionAudio, 0.5F);
        }
        if (destroyEnemy && other.gameObject.tag == "Enemy" || destroyCollectibles && other.gameObject.tag == "Collectible")
        {
            Destroy(other.gameObject);
        }
    }
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
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(collisionAudio, 0.5F);
        }

        if (destroyEnemy == true && hit.gameObject.tag == "Enemy" || destroyCollectibles == true && hit.gameObject.tag == "Collectible")
        {
            Destroy(hit.gameObject);
        }
    }
}