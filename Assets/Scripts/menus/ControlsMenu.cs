using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsMenu : MonoBehaviour
{
    public GameObject controls;
    private void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void closeControls()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Destroy(controls);
    }
}
