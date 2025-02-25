using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyUnlock : MonoBehaviour
{
    // door stuff
    public GameObject door;
    public float speed = 2f;
    private float openHeight;
    public Transform startPos;
    private bool touched;
    // key stuff
    public KeyCollecter keys;
    public bool keyGet;
    private void Start()
    {
        openHeight = startPos.position.y + startPos.localScale.y - 0.5f;
    }
    // Update is called once per frame
    void Update()
    {
        if (keys.GoldKeyGet)
        {
            keyGet = true;
        }
        if (touched)
        {
            door.transform.position = Vector3.Lerp(door.transform.position, new Vector3(door.transform.position.x, openHeight, door.transform.position.z), Time.deltaTime * speed);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (keyGet&&other.CompareTag("Player"))
        {
            touched = true;
        }
    }
}
