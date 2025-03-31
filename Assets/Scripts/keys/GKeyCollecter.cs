using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollecter : MonoBehaviour
{
    public GameObject GoldKeySprite;
    public GameObject GoldKey;
    public bool GoldKeyGet;
    // Start is called before the first frame update
    void Start()
    {
        GoldKeySprite.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GoldKeySprite.SetActive(true);
            Destroy(GoldKey);
            GoldKeyGet = true;
        }
    }
}
