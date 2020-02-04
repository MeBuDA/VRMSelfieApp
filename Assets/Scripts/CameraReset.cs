using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraReset : MonoBehaviour
{
    Vector3 cameraResetPos;
    Quaternion CameraResetAngle;
    void Start()
    {
        cameraResetPos = this.GetComponent<Transform>().position;
        CameraResetAngle = this.GetComponent<Transform>().rotation;
    }
    public void CameraResetButton()
    {
        this.transform.position = cameraResetPos;
        this.transform.rotation = CameraResetAngle;
    }
}
