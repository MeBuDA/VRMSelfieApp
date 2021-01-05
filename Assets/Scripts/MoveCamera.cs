using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] float adjustment = 10f;
    [SerializeField] float adjustmentP = 1000f;
    private Vector3 mousePos;
    int change = 0;
    void Update ()
    {
        switch (change)
        {
            case 0:
                cameraAngleControl ();
                break;
            case 1:
                cameraPosControl ();
                break;
        }
    }
    public void ChangeCameraControl ()
    {
        change++;
        if (change == 2)
        {
            change = 0;
        }

    }

    private void cameraAngleControl ()
    {
        if (Input.GetMouseButtonDown (0))
        {
            mousePos = Camera.main.ScreenToViewportPoint (Input.mousePosition) * Camera.main.fieldOfView / adjustment;
        }
        if (Input.GetMouseButton (0))
        {
            Vector3 diff = mousePos - Camera.main.ScreenToViewportPoint (Input.mousePosition) * Camera.main.fieldOfView / adjustment;

            if (Input.touchSupported)
            {
                diff = mousePos - Camera.main.ScreenToViewportPoint (Input.GetTouch (0).position) * Camera.main.fieldOfView / adjustment;
            }
            diff.z = 0.0f;
            float w = diff.x;
            diff.x = -diff.y;
            diff.y = -w;
            this.transform.eulerAngles += diff;
        }

        if (Input.GetMouseButtonUp (0))
        {
            mousePos = Vector3.zero;
        }
    }
    private void cameraPosControl ()
    {

        if (Input.GetMouseButtonDown (0))
        {
            mousePos = Camera.main.ScreenToViewportPoint (Input.mousePosition) * Camera.main.fieldOfView / adjustmentP;
        }
        if (Input.GetMouseButton (0))
        {
            Vector3 diff = mousePos - Camera.main.ScreenToViewportPoint (Input.mousePosition) * Camera.main.fieldOfView / adjustmentP;

            if (Input.touchSupported)
            {
                diff = mousePos - Camera.main.ScreenToViewportPoint (Input.GetTouch (0).position) * Camera.main.fieldOfView / adjustmentP;
            }
            diff.z = 0.0f;
            diff.x = -diff.x;
            this.transform.position += diff;
        }

        if (Input.GetMouseButtonUp (0))
        {
            mousePos = Vector3.zero;
        }
    }
}