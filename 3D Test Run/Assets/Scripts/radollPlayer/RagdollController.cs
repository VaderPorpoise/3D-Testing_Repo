using System.Collections;
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
           Application.targetFrameRate

        }

        movementvec.x = Input.GetAxisRaw("Horizontal");
        movementvec.z = Input.GetAxisRaw("Vertical");

        if (weaponsManager.hasSword)
        {
            AimSword();

        }


        Roll();
        animate();
    }

    void FixedUpdate()
    {


        isGrounded = false;

        stillVelocity = new Vector3(movementvec.x, hips.velocity.y, movementvec.z);
        hips.velocity = stillVelocity;


        Movement();

        GroundCheck();


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

    void AimGun()
    {




    }
    void AimSword()
    {




    }
    void Movement()
    {


        if (Input.GetKey(KeyCode.LeftShift))
        {

            movementvec.x *= playerSprintMultiplier;
            movementvec.y *= playerSprintMultiplier;

        }


        if (Input.GetKey(KeyCode.W))
        {


            hips.AddForce(hips.transform.up * (playerMovementForce * movementvec.z));
        }



        if (Input.GetKey(KeyCode.A))
        {


            hips.AddForce(-hips.transform.right * (playerStrafeMultiplier * playerMovementForce * movementvec.x));
        }


        if (Input.GetKey(KeyCode.S))
        {

            hips.AddForce(hips.transform.up * (playerMovementForce * movementvec.z));
        }


        if (Input.GetKey(KeyCode.D))
        {

            hips.AddForce(-hips.transform.right * (playerStrafeMultiplier * playerMovementForce * movementvec.x));

        }



        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            hips.AddForce(hips.transform.forward * playerJumpForce, ForceMode.Impulse);
        }




        else if (isGrounded)
        {

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
        if (!isGrounded && targetRagdollAnimator.isAttacking) return;

        if (Mathf.Abs(movementvec.z) > 0)
        {
            //animate walk foreward and backward
            targetRagdollAnimator.changeAnimationState(Ragdoll_Walk, 0);


        }
        else { targetRagdollAnimator.changeAnimationState(Ragdoll_Idle, 0); }


    }



    void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheckTrans.position, GroundThreshold, groundMask);
    }





}
