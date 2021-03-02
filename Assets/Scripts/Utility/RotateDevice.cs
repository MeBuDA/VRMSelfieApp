using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDevice : MonoBehaviour
{
    [SerializeField] RectTransform[] UIRects;
    bool one = true;

    void Update()
    {
        if (Input.deviceOrientation == DeviceOrientation.LandscapeRight && one)
        {
            RotationDevice ();
        }
        else if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft && !one)
        {
            RotationDevice ();
        }
        
    }
    void RotationDevice ()
    {        
        for (int i = 0; i < UIRects.Length; i++)
        {            
            UIRects[i].localPosition = new Vector3 (-(UIRects[i].localPosition.x), UIRects[i].localPosition.y, UIRects[i].localPosition.z);
        }
        one = !one;
    }
}
