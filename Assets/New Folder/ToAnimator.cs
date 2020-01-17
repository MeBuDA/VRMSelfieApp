using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToAnimator : MonoBehaviour
{
    public RuntimeAnimatorController rootAnimator;
    public void SetAnimator(GameObject root)
    {
        var characterAnimator = root.GetComponent<Animator>();
        characterAnimator.runtimeAnimatorController = rootAnimator;
    }
}
