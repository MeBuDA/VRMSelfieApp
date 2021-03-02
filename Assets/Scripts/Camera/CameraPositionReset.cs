using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionReset : MonoBehaviour
{
    public Vector3 initialPosition { get; set; }
    public void Reset()
    {
        this.transform.position = initialPosition;
    }
}
