using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotatingArm : MonoBehaviour
{
    public GameObject rightArm;
    public GameObject leftArm;

    public Text angularVelocity;

    public Text velocity;
    public float radius;
    public ColorChanger rightMagnetColor;
    public ColorChanger leftMagnetColor;

    public Magnet rightMagnet;
    public Magnet leftMagnet;

    public float Kt; // Torque equation constant
    public float Voltage { get; set; }
    public float Amperage { get; set; }

    private new Rigidbody rigidbody;

    private float eulerRotation;
    private float previousAngularVelocity_Y;
    private bool state;

    static private Vector3 positiveIfield = new Vector3(0, -1, 0);
    static private Vector3 negativeIfield = new Vector3(0, 1, 0);

    private Vector3 positive = positiveIfield;
    private Vector3 negative = negativeIfield;

    private Field rightField;
    private Field leftField;

    public AchievementManager achievementManager;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        leftField = leftArm.GetComponent<Field>();
        leftField.FieldVector = positive;

        rightField = rightArm.GetComponent<Field>();
        rightField.FieldVector = positive;

        state = true;
        eulerRotation = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float magneticFlux = Voltage; // (B.S.cosΘ)
        float torque = Kt * Amperage * (Voltage); 


        rigidbody.AddTorque(transform.forward * torque);

        eulerRotation = transform.localRotation.eulerAngles.y;

        float angularVelocity_Y = rigidbody.angularVelocity.y;
        angularVelocity.text =  angularVelocity_Y.ToString("0.##"); // there is only Y axis rotation
        velocity.text = (angularVelocity_Y * radius).ToString("0.#");

        // any Sign change (negative <-> positive)
        if(previousAngularVelocity_Y * angularVelocity_Y < 0){
            rightMagnet.ChangePolarity();
            leftMagnet.ChangePolarity();
        }
        previousAngularVelocity_Y = angularVelocity_Y;

        rightMagnetColor.SetColorStrength(Mathf.Abs(torque));
        leftMagnetColor.SetColorStrength(Mathf.Abs(torque));

        if(rigidbody.angularVelocity.y > 0)
        {
            achievementManager.IncrementAchievement(Achievements.First);
        }
        else
        {
            
        }

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

        if (rotationState)
        {
            //DownConnector.GetComponent<Renderer>().material = darkBlue;
            //UpConnector.GetComponent<Renderer>().material = lightBlue;

        }
        else
        {
            //DownConnector.GetComponent<Renderer>().material = lightBlue;
            //UpConnector.GetComponent<Renderer>().material = darkBlue;

        }
    }

    public void InvertField()
    {
        // fieldValue *= -1;
    }

    /*public void InvertTexture()
    {
        foreach(ScrollTexture coilComponent in CoilComponents)
        {
            coilComponent.InvertTexture();
        }
    }*/
}
