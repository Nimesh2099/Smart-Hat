using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            ScreenCapture.CaptureScreenshot("SmartHat.png");
            Debug.Log("SS Taken");
        }
    }
}
