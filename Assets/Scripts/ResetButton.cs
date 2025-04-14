using UnityEngine;

public class ResetButton : MonoBehaviour
{
    public GameObject box;
    public ButtonRangeDetect rangedetec;
    private bool inTrigger;
    private Vector3 back;
    void Start()
    {
        back = box.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        inTrigger = rangedetec.trigger;
        if (inTrigger && Input.GetKeyDown("e")) 
        {
            box.transform.position=back;
        }
    }
}
