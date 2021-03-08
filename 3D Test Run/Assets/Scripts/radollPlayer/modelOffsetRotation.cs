using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modelOffsetRotation : MonoBehaviour
{
    public bool shoulderRotationOffset;
    public float value;
    Quaternion offsetRot;



    

    // Update is called once per frame
    void Update()
    {
        offsetRot = Quaternion.Euler(new Vector3(0f, value, 0f));
        if (shoulderRotationOffset)
        {
            transform.localRotation = offsetRot * transform.localRotation;

        }
    }
}
