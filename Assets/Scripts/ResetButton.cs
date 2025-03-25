using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        Debug.Log(back);
    }

    // Update is called once per frame
    void Update()
    {
        inTrigger = rangedetec.trigger;
        Debug.Log(inTrigger);
        if (inTrigger && Input.GetKeyDown("e")) 
        {
            box.transform.position=back;
        }
    }
}
