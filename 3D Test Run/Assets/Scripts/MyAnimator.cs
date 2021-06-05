using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAnimator : MonoBehaviour
{
    Animator TargetAnimator;
    public AnimationClip IdleAnimation;
    private string currentState;
    public bool isAttacking = false;
    // Start is called before the first frame update
    void Start()
    {
        TargetAnimator = GetComponent<Animator>();

    }
    void Update()
    {
        // for debugging an animation

       // Debug.Log("State is: "+currentState);
    }

    public void changeAnimationState(string newState, int layerID)
    {




        if (currentState == newState)
        {
            return;
        }
        TargetAnimator.Play(newState, layerID);
        
        currentState = newState;





    }
    float seconds;




}
