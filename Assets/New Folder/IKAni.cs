using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKAni : MonoBehaviour
{
    public Transform CameraAnchorRight { get; set; }
    public Transform CameraAnchorLeft { get; set; }
    public Transform LookAnchor { get; set; }
    public Animator animator { get; set; }

    private float lookTotalWeight = 1.0f;
    private float bodyWeight = 1.0f;
    private float headWeight = 1.0f;
    private float eyeWeight = 0.4f;

    void OnAnimatorIK (int layerIndex)
    {
        if (!animator) return;
#if !UNITY_EDITOR
        if (Input.deviceOrientation == DeviceOrientation.LandscapeRight)
        {
            if (CameraAnchorRight != null)
            {
                animator.SetIKPositionWeight (AvatarIKGoal.RightHand, 1);
                animator.SetIKRotationWeight (AvatarIKGoal.RightHand, 1);
                animator.SetIKPosition (AvatarIKGoal.RightHand, CameraAnchorRight.position);
                animator.SetIKRotation (AvatarIKGoal.RightHand, CameraAnchorRight.rotation);
            }
        }
        if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft)
        {
            if (CameraAnchorLeft != null)
            {
                animator.SetIKPositionWeight (AvatarIKGoal.LeftHand, 1);
                animator.SetIKRotationWeight (AvatarIKGoal.LeftHand, 1);
                animator.SetIKPosition (AvatarIKGoal.LeftHand, CameraAnchorLeft.position);
                animator.SetIKRotation (AvatarIKGoal.LeftHand, CameraAnchorLeft.rotation);
            }
        }
#else 
        animator.SetIKPositionWeight (AvatarIKGoal.RightHand, 1);
        animator.SetIKRotationWeight (AvatarIKGoal.RightHand, 1);
        animator.SetIKPosition (AvatarIKGoal.RightHand, CameraAnchorRight.position);
        animator.SetIKRotation (AvatarIKGoal.RightHand, CameraAnchorRight.rotation);
#endif
        animator.SetLookAtWeight (lookTotalWeight, bodyWeight, headWeight, eyeWeight);
        animator.SetLookAtPosition (LookAnchor.transform.position);
    }
}