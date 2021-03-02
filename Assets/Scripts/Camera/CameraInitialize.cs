using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInitialize : MonoBehaviour
{
    [SerializeField] Transform cameraPos;
    [SerializeField] CameraPositionReset Reset;
    public void CameraPositionInitialize(GameObject root)
    {
        var anim = root.GetComponent<Animator>();
        var modelEye = anim.GetBoneTransform (HumanBodyBones.Head);
        cameraPos.position = modelEye.position;
        Reset.initialPosition = modelEye.position;
    }
}
