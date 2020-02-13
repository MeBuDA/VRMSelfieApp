using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraIni : MonoBehaviour
{
    [SerializeField] Transform cameraPos;
    [SerializeField] CameraReset Reset;
    public void CameraInitilize(GameObject root)
    {
        var anim = root.GetComponent<Animator>();
        var modelEye = anim.GetBoneTransform (HumanBodyBones.Head);
        cameraPos.position = modelEye.position;
        Reset.Ini = modelEye.position;
    }
}
