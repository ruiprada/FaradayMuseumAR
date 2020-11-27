using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorqueVector : MonoBehaviour
{
    public Transform LeftMagnet;

    public GameObject t;

    private LineRenderer t_lineRenderer;

    public Field B_field;
    public Field I_field;
    private Vector3 T_field;
    // Start is called before the first frame update
    void Start()
    {
        t_lineRenderer = t.GetComponent<LineRenderer>();

        t_lineRenderer.positionCount = 2;


        t_lineRenderer.useWorldSpace = false;


        T_field = Vector3.Cross(B_field.FieldVector, I_field.FieldVector);
    }

    // Update is called once per frame
    void Update()
    {
        T_field = Vector3.Cross(B_field.FieldVector, I_field.FieldVector);

        transform.position = LeftMagnet.position;

        t_lineRenderer.SetPosition(0, Vector3.zero);
        t_lineRenderer.SetPosition(1, T_field);
    }
}
