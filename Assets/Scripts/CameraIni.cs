using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraIni : MonoBehaviour
{
    [SerializeField] Transform cameraPos;
    public void CameraInitilize(GameObject root)
    {
        var anim = root.GetComponent<Animator>();
        var modelEye = anim.GetBoneTransform (HumanBodyBones.Head);
        cameraPos.position = modelEye.position;
    }
}
