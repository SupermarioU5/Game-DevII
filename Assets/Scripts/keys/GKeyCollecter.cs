using UnityEngine;

public class KeyCollecter : MonoBehaviour
{
    public GameObject GoldKeySprite;
    public GameObject GoldKey;
    public bool GoldKeyGet;
    public AudioSource collect;
    // Start is called before the first frame update
    void Start()
    {
        GoldKeySprite.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            collect.PlayOneShot(collect.clip);
            GoldKeySprite.SetActive(true);
            Destroy(GoldKey);
            GoldKeyGet = true;
        }
    }
}
