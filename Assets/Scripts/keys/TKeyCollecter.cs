using UnityEngine;

public class TKeyCollecter : MonoBehaviour
{
    public GameObject triangleKeySprite;
    public GameObject triangleKey;
    public bool triangleKeyGet;
    public AudioSource collect;
    // Start is called before the first frame update
    void Start()
    {
        triangleKeySprite.SetActive(false);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            collect.PlayOneShot(collect.clip);
            triangleKeySprite.SetActive(true);
            Destroy(triangleKey);
            triangleKeyGet = true;
        }
    }
}