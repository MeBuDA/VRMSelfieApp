using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKInitialize : MonoBehaviour
{
    [SerializeField] Transform cameraAnchorRight;
    [SerializeField] Transform cameraAnchorLeft;
    [SerializeField] Transform lookAnchor;

    public void IKInitilize(GameObject root)
    {
        root.AddComponent<IKAnimationSet>();
        var VRM = root.GetComponent<IKAnimationSet>();
        VRM.animator = root.GetComponent<Animator>();
        VRM.CameraAnchorLeft = cameraAnchorLeft;
        VRM.CameraAnchorRight = cameraAnchorRight;
        VRM.LookAnchor = lookAnchor;
    }
}
