using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        inputManager = GetComponent<InputManager>();
        Cursor.lockState = CursorLockMode.Locked;


    }

    // Update is called once per frame
    void Update()
    {

        mouseX += Input.GetAxis("Mouse X") * Time.deltaTime * inputManager.mouseSensitivity;
        mouseY -= Input.GetAxis("Mouse Y") * Time.deltaTime * inputManager.mouseSensitivity;

        Quaternion targetRot = Quaternion.Euler(mouseY, mouseX, 0);

        followTargetTrans.rotation = targetRot;

       

        hipJoint.targetRotation = Quaternion.Euler(0, 0, -mouseX);
        stomachJoint.targetRotation = Quaternion.Euler(mouseY, 0, 0);
    }



}
