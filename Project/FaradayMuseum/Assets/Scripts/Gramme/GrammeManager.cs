using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrammeManager : MonoBehaviour
{
    public Material northPole;
    public Material southPole;

    public Magnet LeftMagnet;
    public Magnet RightMagnet;
    public RotatingArm RotatingArm;
    // Start is called before the first frame update
    void Awake()
    {
        LeftMagnet.GetComponent<Magnet>().IsNorth = false;
        RightMagnet.GetComponent<Magnet>().IsNorth = true;          
    }

    // Update is called once per frame
    public void ChangePolarity()
    {
        RotatingArm.InvertField();

        /*foreach (Transform magneticField in MagneticFields.transform) {
            magneticField.transform.Rotate(0.0f, 0.0f, 180.0f, Space.Self);
        }
        */
    }

    public void InvertField(){
        RotatingArm.InvertField();
    }
}
