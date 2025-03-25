using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonRangeDetect : MonoBehaviour
{
    public bool trigger;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trigger = false;
        }
    }
}
