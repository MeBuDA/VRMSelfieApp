using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraAttach : MonoBehaviour
{
    Canvas canvas;
    void Start ()
    {
        canvas = this.GetComponent<Canvas> ();
    }
    void Update ()
    {
        if (canvas.worldCamera == null)
        {
            canvas.worldCamera = Camera.main;
        }
    }
}