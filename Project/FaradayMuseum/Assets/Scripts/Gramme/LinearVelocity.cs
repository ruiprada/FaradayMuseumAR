using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearVelocity : MonoBehaviour
{

    public Transform sphere;
    public Rigidbody rotating;

    [Range(0,1)]
    public float vectorSizeMultiplicator = 0.15f;

    // Update is called once per frame
    void Update()
    {
        // v = ω x r
        Vector3 angularVelocity = rotating.angularVelocity * vectorSizeMultiplicator;
        Vector3 radiusVector = (sphere.position - transform.position);

        Vector3 velocity = Vector3.Cross(radiusVector, angularVelocity);

        // Debug.DrawRay(transform.position, velocity, Color.red);

        //Vector3 right = Quaternion.LookRotation(velocity) * Quaternion.Euler(0,180+20.0f,0) * new Vector3(0,0,1);
        // Vector3 left = Quaternion.LookRotation(velocity) * Quaternion.Euler(0,180-20.0f,0) * new Vector3(0,0,1);
        // Debug.DrawRay(transform.position + velocity, right * 0.03f, Color.white);
        // Debug.DrawRay(transform.position + velocity, left * 0.03f, Color.white);

    }
}
