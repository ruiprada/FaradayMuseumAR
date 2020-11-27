using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingArm : MonoBehaviour
{
    public float speed;
    //public GameObject DownConnector;
    //public GameObject UpConnector;

    //public Material darkBlue;
    //public Material lightBlue;

    public GameObject rightArm;
    public GameObject leftArm;

    //public ScrollTexture[] CoilComponents;

    public LongClickButton longClickButton;

    public float Torque { get; set; }
    private int field;

    private new Rigidbody rigidbody;

    private float eulerRotation;
    private bool state;

    static private Vector3 positiveIfield = new Vector3(0, -1, 0);
    static private Vector3 negativeIfield = new Vector3(0, 1, 0);

    private Vector3 positive = positiveIfield;
    private Vector3 negative = negativeIfield;

    private Field rightField;
    private Field leftField;


    // Start is called before the first frame update
    void Start()
    {
        Torque = speed;
        rigidbody = GetComponent<Rigidbody>();

        leftField = leftArm.GetComponent<Field>();
        leftField.FieldVector = positive;


        rightField = rightArm.GetComponent<Field>();
        rightField.FieldVector = positive;

        state = true;
        eulerRotation = 0;
        field = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(0, speed * Time.deltaTime, 0);

        int myModifier = 0;

        if (field == 1)
        {
            myModifier = -1;
        }
        else
        {
            myModifier = 1;

        }

        float h = myModifier * (longClickButton.pointerDown ? 1 : 0) * Torque * Time.deltaTime;


        //Todo h depends on the Vectors

        rigidbody.AddTorque(transform.forward * h);

        eulerRotation = transform.localRotation.eulerAngles.y;

        if (state)
        {
            if (eulerRotation > 180)
            {
                state = false;
                ChangeCurrent(state);
            }
        }
        else
        {
            if (eulerRotation < 180)
            {
                state = true;
                ChangeCurrent(state);
            }
        }
    }

    void ChangeCurrent(bool rotationState)
    {
        leftField.Invert();
        rightField.Invert();

        //InvertTexture();

        if (rotationState) {
            //DownConnector.GetComponent<Renderer>().material = darkBlue;
            //UpConnector.GetComponent<Renderer>().material = lightBlue;

        } else {
            //DownConnector.GetComponent<Renderer>().material = lightBlue;
            //UpConnector.GetComponent<Renderer>().material = darkBlue;

        }
    }

    public void InvertField()
    {
        field *= -1;
    }

    /*public void InvertTexture()
    {
        foreach(ScrollTexture coilComponent in CoilComponents)
        {
            coilComponent.InvertTexture();
        }
    }*/
}
