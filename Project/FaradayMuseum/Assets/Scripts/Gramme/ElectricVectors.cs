using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricVectors : MonoBehaviour
{
    public Transform RotatingArm;

    private float deltaDegrees;
    private float rotationDegrees;
    // Start is called before the first frame update
    void Start()
    {
        float rotationDegrees = 90;
    }

    // Update is called once per frame
    void Update()
    {
        deltaDegrees = RotatingArm.localRotation.eulerAngles.y - rotationDegrees;
        //transform.GetChild(0).position = LeftArm.position; //LeftField
        //transform.GetChild(1).position = RightArm.position; //RightField
        rotationDegrees = RotatingArm.localRotation.eulerAngles.y;


        transform.Rotate(0, deltaDegrees , 0, Space.World);
    }
}
