using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragImage : MonoBehaviour
{
    [SerializeField] RectTransform rect;
    [SerializeField] RectTransform root;
    private Vector3 mousePos;
    void Update()
    {
        Drag();
    }
    private void Drag()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition) * Camera.main.fieldOfView;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 diff = mousePos - Camera.main.ScreenToViewportPoint(Input.mousePosition) * Camera.main.fieldOfView;

            if (Input.touchSupported)
            {
                diff = mousePos - Camera.main.ScreenToViewportPoint(Input.GetTouch(0).position) * Camera.main.fieldOfView;
            }
            diff = Vector3.Scale(diff, Vector3.up);
            rect.position += diff;
        }
        if (Input.GetMouseButtonUp(0))
        {
            mousePos = Vector3.zero;
        }

        //画像範囲内のみ対応
        var range = rect.sizeDelta.y / 2f - root.sizeDelta.y / 2f;
        Debug.Log(range);
        if (range < rect.localPosition.y)
        {
            rect.localPosition = new Vector3(0, range, 0);
        }
        if (-range > rect.localPosition.y)
        {
            rect.localPosition = new Vector3(0, -range, 0);
        }
    }
}
