using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SKeyUnlock : MonoBehaviour
{
    // door stuff
    public GameObject door;
    public Renderer doorR;
    private float speed = 4f;
    private float openHeight;
    public Transform startPos;
    private bool touched;
    public Material mat1;
    public AudioSource open;
    private bool played;
    // key stuff
    public SKeyCollecter keys;
    private bool keyGet;
    private void Start()
    {
        openHeight = startPos.position.y + startPos.localScale.y - 0.5f;
    }
    // Update is called once per frame
    void Update()
    {
        if (keys.SkeleKeyGet)
        {
            keyGet = true;
        }
        if (touched)
        {
            if (!played)
            {
                open.PlayOneShot(open.clip);
                played = true;
            }
            door.transform.position = Vector3.Lerp(door.transform.position, new Vector3(door.transform.position.x, openHeight, door.transform.position.z), Time.deltaTime * speed);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (keyGet&&other.CompareTag("Player"))
        {
            touched = true;
            doorR.material=mat1;
        }
    }
}
