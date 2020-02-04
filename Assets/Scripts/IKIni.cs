using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKIni : MonoBehaviour
{
    [SerializeField] Transform cameraAnchorRight;
    [SerializeField] Transform cameraAnchorLeft;
    [SerializeField] Transform lookAnchor;

    public void IKInitilize(GameObject root)
    {
        root.AddComponent<IKAni>();
        var VRM = root.GetComponent<IKAni>();
        VRM.animator = root.GetComponent<Animator>();
        VRM.CameraAnchorLeft = cameraAnchorLeft;
        VRM.CameraAnchorRight = cameraAnchorRight;
        VRM.LookAnchor = lookAnchor;
    }
}
