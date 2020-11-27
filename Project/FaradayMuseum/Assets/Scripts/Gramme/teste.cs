using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teste : MonoBehaviour
{
    public float speed;
    public float Torque { get; set; }
    private new Rigidbody rigidbody;

    private float eulerRotation;
    private bool state;

    // Start is called before the first frame update
    void Start()
    {
        Torque = speed;
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.AddTorque(transform.forward * Torque * Time.deltaTime);
    }
}
