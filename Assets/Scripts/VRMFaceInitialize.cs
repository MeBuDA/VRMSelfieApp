using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRM;

public class VRMFaceInitialize : MonoBehaviour
{
    //[SerializeField] VRMFaceTracker VRMFace;

    public void FaceInitialize(GameObject root)
    {
        var anim = root.GetComponent<Animator>();
        var proxy = root.GetComponent<VRMBlendShapeProxy>();
        //VRMFace.head = anim.GetBoneTransform (HumanBodyBones.Head);
        //VRMFace.proxy = proxy;
    }
}
