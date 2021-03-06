﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class RagdollController : MonoBehaviour
{
    //animation strings
    //this is base layer0
    [SerializeField]
    AnimationClip Ragdoll_Idle;
    [SerializeField]
    AnimationClip Ragdoll_Sprint;
    [SerializeField]
    AnimationClip Ragdoll_Walk;

    //this is layer1

    [Header("player settings")]

    public float playerMovementForce = 10f;
    float playerStrafeMultiplier = 0.6f;



    float playerSprintMultiplier = 1.5f;
    float playerJumpForce = 100;


    float GroundThreshold = 0.4f;



    public Transform groundCheckTrans;
    public LayerMask groundMask;


    public Rigidbody hips;

    [Header("cached components")]

    PlayerWeaponsManager weaponsManager;

    public MyAnimator targetRagdollAnimator;
    bool isGrounded;


    public float playerFloatForce = 50f;

    //snappy controlls

    Vector3 movementvec;


    Vector3 stillVelocity;

    
    void Start()
    {

        weaponsManager = GetComponent<PlayerWeaponsManager>();
        //targetRagdollAnimator.changeAnimationState(Ragdoll_Idle, 0);

    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Y))
        {


        }

        movementvec.x = Input.GetAxisRaw("Horizontal");
        movementvec.z = Input.GetAxisRaw("Vertical");





        animate();
    }

    void FixedUpdate()
    {


        isGrounded = false;

        stillVelocity = new Vector3(movementvec.x, hips.velocity.y, movementvec.z);
        hips.velocity = stillVelocity;



        Movement();
     
      


    }
    void Roll()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt) && movementvec.z > 0)
        {

        }
        if (Input.GetKeyDown(KeyCode.LeftAlt) && movementvec.x > 0)
        {

        }
    }
    void PunchMode()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {

        }

    }


    void Movement()
    {

        GroundCheck();
        if (Input.GetKey(KeyCode.LeftShift))
        {

            movementvec.x *= playerSprintMultiplier;
            movementvec.y *= playerSprintMultiplier;


        }


        if (Input.GetKey(KeyCode.W))
        {


            hips.AddForce(hips.transform.forward * (playerMovementForce * movementvec.z));
        }



        if (Input.GetKey(KeyCode.A))
        {


            hips.AddForce(hips.transform.right * (playerStrafeMultiplier * playerMovementForce * movementvec.x));
        }


        if (Input.GetKey(KeyCode.S))
        {

            hips.AddForce(hips.transform.forward * (playerMovementForce * movementvec.z));
        }


        if (Input.GetKey(KeyCode.D))
        {

            hips.AddForce(hips.transform.right * (playerStrafeMultiplier * playerMovementForce * movementvec.x));

        }



        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            hips.AddForce(hips.transform.up * playerJumpForce, ForceMode.Impulse);
        }




        else if (isGrounded)
        {
            Debug.Log("floating");

            FloatCharacter();
        }


    }


    void FloatCharacter()
    {
        hips.AddForce(Vector3.up * playerFloatForce);

    }
    #region myOwnLeanScript
    void lean()
    {

    }
    #endregion


    void animate()
    {
        // if (weaponsManager.hasGun || weaponsManager.hasSword) return;

        if (Mathf.Abs(movementvec.z) > 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                targetRagdollAnimator.changeAnimationState(Ragdoll_Sprint.name, 0);
                return;
            }
            //animate walk foreward and backward
            targetRagdollAnimator.changeAnimationState(Ragdoll_Walk.name, 0);


        }
        else
        {

            targetRagdollAnimator.changeAnimationState(Ragdoll_Idle.name, 0);
        }




    }



    void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheckTrans.position, GroundThreshold, groundMask);
    }





}
