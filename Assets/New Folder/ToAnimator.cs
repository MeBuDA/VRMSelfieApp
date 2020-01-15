using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToAnimator : MonoBehaviour
{
    public RuntimeAnimatorController rootAnimator;
    Animator characterAnimator;
    void Start()
    {
        characterAnimator = this.transform.GetChild(0).gameObject.GetComponent<Animator>();
        characterAnimator.runtimeAnimatorController = rootAnimator;
    }
    void Update()
    {
        if(characterAnimator.runtimeAnimatorController == null)
        {
            characterAnimator.runtimeAnimatorController = rootAnimator;
        }
    }
}
