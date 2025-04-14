using UnityEngine;

public class winscreen : MonoBehaviour
{
    public AudioSource winSound;
    public AudioSource winAudio;
    private bool notPlayed = true;
    // Start is called before the first frame update
    void Start()
    {
        winSound.PlayOneShot(winSound.clip);
    }

    // Update is called once per frame
    void Update()
    {
        if (!winSound.isPlaying && notPlayed)
        {
            winAudio.PlayOneShot(winAudio.clip);
            notPlayed = false;
        }
    }
}
