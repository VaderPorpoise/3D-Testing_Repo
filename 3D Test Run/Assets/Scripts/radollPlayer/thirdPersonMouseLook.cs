using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class thirdPersonMouseLook : MonoBehaviour
{
    [Header("variables")]

    float xRotation = 0;

    float mouseY;
    float mouseX;
    public float XRot
    {
        get
        {
            return xRotation;
        }

    }



    [Header("cached components")]

    InputManager inputManager;

    public Transform followTargetTrans;

    public ConfigurableJoint hipJoint, stomachJoint;

    float stomachOffset = 0;

    public Transform GunMount;

    // Start is called before the first frame update
    void Start()
    {
        inputManager = GetComponent<InputManager>();
        Cursor.lockState = CursorLockMode.Locked;
        setStartingVCam();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse3))
        {
            ChangeVCamTrigger();
        }
        mouseX += Input.GetAxis("Mouse X") * Time.deltaTime * inputManager.mouseSensitivity;
        mouseY -= Input.GetAxis("Mouse Y") * Time.deltaTime * inputManager.mouseSensitivity;

        TPSCamLook();
       // FPSCamLook();

    }
    void FixedUpdate()
    {
        rotategun();
    }

    void TPSCamLook()
    {
        Quaternion targetRot = Quaternion.Euler(mouseY, mouseX, 0);

        followTargetTrans.rotation = targetRot;

        hipJoint.targetRotation = Quaternion.Euler(0, -mouseX, 0);

       stomachJoint.targetRotation = Quaternion.Euler(mouseY + stomachOffset, 0, 0);
    }

    void FPSCamLook()
    {
        FPS.gameObject.transform.rotation = Quaternion.Euler(mouseY, mouseX, 0);

       hipJoint.targetRotation = Quaternion.Euler(0, 0, -mouseX);

        stomachJoint.targetRotation = Quaternion.Euler(mouseY + stomachOffset, 0, 0);

    }
    void rotategun()
    {
        GunMount.localRotation = Quaternion.Euler(mouseY, mouseX, 0);

    }

    public CinemachineVirtualCamera TPS;
    public CinemachineVirtualCamera FPS;
    bool IsFPS;
    void ChangeVCamTrigger()
    {
        Debug.Log("changed to");
        if (IsFPS)
        {
            TPS.Priority = 10;
            FPS.Priority = 0;
            Debug.Log("TPS!");
        }
        else
        {
            FPS.Priority = 10;
            TPS.Priority = 0;
            Debug.Log("FPS!");
        }
        IsFPS = !IsFPS;


    }

    void setStartingVCam()
    {
        FPS.Priority = 10;
    }
}
