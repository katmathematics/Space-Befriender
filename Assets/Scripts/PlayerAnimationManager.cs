using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    public AnimationClip anim;
    public float waitTime;

    private Animator myAnimator;
 
    void Start () {
        myAnimator = GetComponent<Animator>();
        waitTime = anim.length + 6f;
        InvokeRepeating ("PlayAnim", 6f, waitTime);
    }
 
    void PlayAnim () {
        myAnimator.Play("Blink");
    }
}