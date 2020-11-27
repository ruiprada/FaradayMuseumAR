using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrammeManager : MonoBehaviour
{
    public GameObject MagneticFields;

    public Material northPole;
    public Material southPole;

    public Magnet LeftMagnet;
    public Magnet RightMagnet;

    public Field MagneticField;
    public RotatingArm RotatingArm;
    // Start is called before the first frame update
    void Awake()
    {
        LeftMagnet.GetComponent<Magnet>().IsNorth = false;
        RightMagnet.GetComponent<Magnet>().IsNorth = true;

        MagneticField.FieldVector = new Vector3(1, 0, 0);

        /*RightMagnet.NorthPole = northPole;
        RightMagnet.SouthPole = southPole;

        LeftMagnet.NorthPole = northPole;
        LeftMagnet.SouthPole = southPole;
        */
          
    }

    // Update is called once per frame
    void Update()
    {
        if (LeftMagnet.IsNorth)
        {
            MagneticField.FieldVector = Vector3.Normalize(RightMagnet.gameObject.transform.position - LeftMagnet.gameObject.transform.position);
        }
        else
        {
            MagneticField.FieldVector = Vector3.Normalize(LeftMagnet.gameObject.transform.position - RightMagnet.gameObject.transform.position);
        }
    }

    public void ChangePolarity()
    {

        // LeftMagnet.ChangePolarity();
        // RightMagnet.ChangePolarity();

        MagneticField.Invert();

        RotatingArm.InvertField();

        foreach (Transform magneticField in MagneticFields.transform) {
            magneticField.transform.Rotate(0.0f, 0.0f, 180.0f, Space.Self);
        }
    }
}
