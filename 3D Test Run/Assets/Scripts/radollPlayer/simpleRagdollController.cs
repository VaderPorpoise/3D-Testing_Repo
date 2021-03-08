using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleRagdollController : MonoBehaviour
{
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



    public Animator targetRagdollAnimator;
    bool isGrounded;


    float playerMovementFloatForce = 50f;

    //snappy controlls


    Vector3 movementvec;


    Vector3 stillVelocity;

    void Start()
    {




    }
    void Update()
    {

        movementvec.x = Input.GetAxisRaw("Horizontal");
        movementvec.z = Input.GetAxisRaw("Vertical");


    }

    void FixedUpdate()
    {

        targetRagdollAnimator.SetBool("isRunning", false);
        isGrounded = false;
        GroundCheck();
        stillVelocity = new Vector3(movementvec.x, hips.velocity.y, movementvec.z);
        hips.velocity = stillVelocity;


        movement();
    }
    void movement()
    {
        if (Input.GetKey(KeyCode.W))
        {


            if (Input.GetKey(KeyCode.LeftShift))
            {
                targetRagdollAnimator.SetBool("isRunning", true);

                hips.AddForce(hips.transform.up * (playerMovementForce * playerSprintMultiplier * movementvec.z));
                return;

            }
            hips.AddForce(hips.transform.up * (playerMovementForce * movementvec.z));


        }
        if (Input.GetKey(KeyCode.A))
        {


            if (Input.GetKey(KeyCode.LeftShift))
            {
                targetRagdollAnimator.SetBool("isRunning", true);
                hips.AddForce(-hips.transform.right * (playerStrafeMultiplier * playerMovementForce * playerSprintMultiplier * movementvec.x));
                return;
            }

            hips.AddForce(-hips.transform.right * (playerStrafeMultiplier * playerMovementForce * movementvec.x));
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                targetRagdollAnimator.SetBool("isRunning", true);
                hips.AddForce(-hips.transform.right * (playerStrafeMultiplier * playerMovementForce * playerSprintMultiplier * movementvec.x));
                return;
            }
            hips.AddForce(-hips.transform.right * (playerStrafeMultiplier * playerMovementForce * movementvec.x));

        }
        if (Input.GetKey(KeyCode.S))
        {

            if (Input.GetKey(KeyCode.LeftShift))
            {
                targetRagdollAnimator.SetBool("isRunning", true);
                hips.AddForce(hips.transform.up * (playerMovementForce * playerSprintMultiplier * movementvec.z));
                return;
            }
            hips.AddForce(hips.transform.up * (playerMovementForce * movementvec.z));
        }
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {

            hips.AddForce(hips.transform.forward * playerJumpForce, ForceMode.Impulse);

        }
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






    void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheckTrans.position, GroundThreshold, groundMask);
    }

}
