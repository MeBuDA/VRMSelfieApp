using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraReset : MonoBehaviour
{
    public Vector3 Ini { get; set; }
    public void Reset()
    {
        this.transform.position = Ini;
    }
}
