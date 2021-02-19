using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class RagdollController : MonoBehaviour
{
    [Header("player settings")]

    public float playerMovementForce = 5f;
    float playerMovementFloatForce = 50f;


    float playerSprintMultiplier = 2f;
    float playerJumpForce = 100;


    float GroundThreshold = 0.4f;


    Vector3 movementVector;

    public Transform groundCheckTrans;
    public LayerMask groundMask;


    public Rigidbody hips;

    [Header("cached components")]



    public Animator targetRagdollAnimator;
    bool isGrounded;



    bool isJumping = false;
    void Start()
    {




    }
    void Update()
    {



        Playerdirection();

        GroundCheck();

        CheckJump();
        isGrounded = false;
    }

    void FixedUpdate()
    {
        ApplyMovement();


    }

    void FloatCharacter()
    {
        hips.AddForce(hips.transform.forward * playerMovementFloatForce);
    }
    #region myOwnLeanScript
    void lean()
    {

    }
    #endregion

    void Playerdirection()
    {



        movementVector.x = Input.GetAxis("Horizontal") * playerMovementForce;

        movementVector.z = Input.GetAxis("Vertical") * playerMovementForce;

        targetRagdollAnimator.SetBool("isRunning", false);
        if (movementVector.z > 0 || movementVector.z < 0)
        {
            targetRagdollAnimator.SetBool("isRunning", true);
            //FloatCharacter();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {

            movementVector.x = Input.GetAxis("Horizontal") * playerSprintMultiplier * playerMovementForce;
            movementVector.z = Input.GetAxis("Vertical") * playerSprintMultiplier * playerMovementForce;
        }
    }
    void CheckJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }
    }


    void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheckTrans.position, GroundThreshold, groundMask);
    }
    void ApplyMovement()
    {

        movementVector.y = hips.velocity.y;

        hips.velocity = (movementVector);




        if (isJumping)
        {

            hips.AddForce(hips.transform.forward * playerJumpForce, ForceMode.Impulse);

            //jump 

            isJumping = false;
        }
    }
}
