using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAnimator : MonoBehaviour
{
    Animator TargetAnimator;
    public AnimationClip IdleAnimation;
    private AnimationClip currentState;
    public bool isAttacking = false;
    // Start is called before the first frame update
    void Start()
    {
        TargetAnimator = GetComponent<Animator>();

    }
    public void changeAnimationState(AnimationClip newState, int layerID)
    {
        if (currentState == newState) return;

        TargetAnimator.Play(newState.name, layerID);
        //  Debug.Log("statechange1");
        currentState = newState;

    }
    float seconds;

  
   

}
