using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsSetup : MonoBehaviour
{
    void Awake ()
    {
        Application.targetFrameRate = 30;
    }
}