using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    // get animation variable and convert into hash
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");

    protected Animator animator;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Move(Vector2 obj)
    {
        animator.SetBool(IsMoving, obj.magnitude > .5f);  // convert IsMoving to true only if entity moved more than .5f vector2
    }
}
