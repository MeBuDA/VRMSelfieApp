using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] float adjustment = 10f;
    [SerializeField] float adjustmentP = 1000f;
    private Vector3 mousePos;
    int change = 0;
    float viewMin = 20.0f;
    float viewMax = 60.0f;

    float vMin = 1.0f;
    float vMax = 5.0f;
    private float backDist = 0.0f;
    float view = 60.0f;
    float v = 1.0f;

    void Update ()
    {
        switch (change)
        {
            case 0:
            cameraAngleControl();
            break;
            case 1:
            cameraPosControl();
            break;
            case 2:
            cameraPinchInOut();
            break;
        }
    }
    public void ChangeCameraControl()
    {
        change++;
        if(change==3)
        {
            change=0;
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
    private void cameraPinchInOut()
    {
        if (Input.touchCount >= 2)
        {
            Touch t1 = Input.GetTouch (0);
            Touch t2 = Input.GetTouch (1);

            if (t2.phase == TouchPhase.Began)
            {
                backDist = Vector2.Distance (t1.position, t2.position);
            }
            else if (t1.phase == TouchPhase.Moved && t2.phase == TouchPhase.Moved)
            {
                // タッチ位置の移動後、長さを再測し、前回の距離からの相対値を取る。
                float newDist = Vector2.Distance (t1.position, t2.position);
                view = view + (backDist - newDist) / 100.0f;
                v = v + (newDist - backDist) / 1000.0f;

                // 限界値をオーバーした際の処理
                if(v > vMax)
                {
                    v = vMax;
                }
                else if(v < vMin)
                {
                    v = vMin;
                }

                // 相対値が変更した場合、カメラに相対値を反映させる
                if(v != 0)
                {
                    this.transform.localPosition = new Vector3(0,0,v);
                }
            }
        }
    }
}