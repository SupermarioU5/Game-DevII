using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform spawn;
    public GameObject thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (thePlayer.transform.position.y<-5)
        {
            thePlayer.transform.position = spawn.transform.position;
        }
    }
}
