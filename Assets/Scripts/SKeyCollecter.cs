using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SKeyCollecter : MonoBehaviour
{
    public GameObject SkeleKeySprite;
    public GameObject SkeleKey;
    public bool SkeleKeyGet;
    // Start is called before the first frame update
    void Start()
    {
        SkeleKeySprite.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SkeleKeySprite.SetActive(true);
            Destroy(SkeleKey);
            SkeleKeyGet = true;
        }
    }
}
