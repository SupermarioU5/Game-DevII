using UnityEngine;

public class SKeyCollecter : MonoBehaviour
{
    public GameObject SkeleKeySprite;
    public GameObject SkeleKey;
    public bool SkeleKeyGet;
    public AudioSource collect;
    // Start is called before the first frame update
    void Start()
    {
        SkeleKeySprite.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            collect.PlayOneShot(collect.clip);
            SkeleKeySprite.SetActive(true);
            Destroy(SkeleKey);
            SkeleKeyGet = true;
        }
    }
}
