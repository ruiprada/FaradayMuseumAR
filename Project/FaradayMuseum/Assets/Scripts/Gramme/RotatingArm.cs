using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotatingArm : MonoBehaviour
{
    public Text angularVelocity;

    public Text velocity;

    public float Voltage { get; set; }
    public float Amperage { get; set; }

    private new Rigidbody rigidbody;

    private float eulerRotation;
    static private Vector3 positiveIfield = new Vector3(0, -1, 0);
    static private Vector3 negativeIfield = new Vector3(0, 1, 0);
    public float Torque {get; set;}

    public GrammeSpecification grammeSpecification;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float magneticFlux = Voltage; // (B.S.cosΘ)

        Torque = grammeSpecification.Kt * Amperage * Voltage;

        rigidbody.AddTorque(transform.forward * Torque);

        eulerRotation = transform.localRotation.eulerAngles.y;

        float angularVelocity_Y = rigidbody.angularVelocity.y;
        angularVelocity.text =  angularVelocity_Y.ToString("0.##"); // there is only Y axis rotation
        velocity.text = (angularVelocity_Y * grammeSpecification.coilRadius).ToString("0.#");
    }
}
