using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class MeasurementTool : MonoBehaviour
{
    public bool mm = true;
    public GameObject rightArrow;
    public GameObject leftArrow;

    public float Arrowscale;
    public float ArrowAngle = 0;
    public Color arrowColor;

    public TextMeshProUGUI measurementTxt;

    public float textScale;
    public Color textColor;
    public GameObject textCanvas;

    float distance;


    void OnDrawGizmos()
    {
        Measure();
    }
    void Measure()
    {
        distance = Vector3.Distance(leftArrow.transform.position, rightArrow.transform.position);
        if (mm)
        {

            distance /= 100f;
            measurementTxt.text = distance.ToString("N2") + "mm";
        }
        else measurementTxt.text = distance.ToString("N2") + "m";
       // textCanvas.transform.position = LerpByDistance(leftArrow.transform.position, rightArrow.transform.position,0.5f);

    }
    Vector3 LerpByDistance(Vector3 A, Vector3 B, float x)
    {

        Vector3 P = A + x * (B - A);
        return P;
    }





}
