using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKAni : MonoBehaviour
{
    public Transform cameraAnchorRight;
    public Transform cameraAnchorLeft;
    public Transform LookAnchor;
    [SerializeField, Range (0.0f, 1.0f)]
    private float lookTotalWeight = 0.0f;
    [SerializeField, Range (0.0f, 1.0f)]
    private float bodyWeight = 0.0f;
    [SerializeField, Range (0.0f, 1.0f)]
    private float headWeight = 0.0f;
    [SerializeField, Range (0.0f, 1.0f)]
    private float eyeWeight = 0.0f;
    private Animator animator;

    void Start ()
    {
        //animator = this.transform.GetChild (0).gameObject.GetComponent<Animator> ();
        animator = GetComponent<Animator> ();
    }

    void OnAnimatorIK (int layerIndex)
    {
        if (!animator) return;
        # if !UNITY_EDITOR
        if (Input.deviceOrientation == DeviceOrientation.LandscapeRight)
        {
            if (cameraAnchorRight != null)
            {
                animator.SetIKPositionWeight (AvatarIKGoal.RightHand, 1);
                animator.SetIKRotationWeight (AvatarIKGoal.RightHand, 1);
                animator.SetIKPosition (AvatarIKGoal.RightHand, cameraAnchorRight.position);
                animator.SetIKRotation (AvatarIKGoal.RightHand, cameraAnchorRight.rotation);
            }
        }
        if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft)
        {
            if (cameraAnchorLeft != null)
            {
                animator.SetIKPositionWeight (AvatarIKGoal.LeftHand, 1);
                animator.SetIKRotationWeight (AvatarIKGoal.LeftHand, 1);
                animator.SetIKPosition (AvatarIKGoal.LeftHand, cameraAnchorLeft.position);
                animator.SetIKRotation (AvatarIKGoal.LeftHand, cameraAnchorLeft.rotation);
            }
        }
        #else 
                        animator.SetIKPositionWeight (AvatarIKGoal.RightHand, 1);
                        animator.SetIKRotationWeight (AvatarIKGoal.RightHand, 1);
                        animator.SetIKPosition (AvatarIKGoal.RightHand, cameraAnchorRight.position);
                        animator.SetIKRotation (AvatarIKGoal.RightHand, cameraAnchorRight.rotation);
        #endif
        animator.SetLookAtWeight (lookTotalWeight, bodyWeight, headWeight, eyeWeight);
        animator.SetLookAtPosition (LookAnchor.transform.position);
    }
}