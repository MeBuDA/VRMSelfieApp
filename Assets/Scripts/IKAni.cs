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
    private float headWeight = 0f;
    private float eyeWeight = 0.4f;

    void OnAnimatorIK (int layerIndex)
    {
        animator.SetIKPositionWeight (AvatarIKGoal.RightHand, 1);
        animator.SetIKRotationWeight (AvatarIKGoal.RightHand, 1);
        animator.SetIKPosition (AvatarIKGoal.RightHand, CameraAnchorRight.position);
        animator.SetIKRotation (AvatarIKGoal.RightHand, CameraAnchorRight.rotation);

        animator.SetLookAtWeight (lookTotalWeight, bodyWeight, headWeight, eyeWeight);
        animator.SetLookAtPosition (LookAnchor.transform.position);
    }
}