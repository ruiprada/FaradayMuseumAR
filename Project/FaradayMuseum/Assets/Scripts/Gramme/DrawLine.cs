using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    // Start is called before the first frame update
    private LineRenderer lineRenderer;
    private float counter;
    private float dist;

    public Transform origin;
    public Transform destination;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, origin.position);
        lineRenderer.SetPosition(1, destination.position);
        lineRenderer.startWidth = .1f;
        lineRenderer.endWidth = .1f;

        dist = Vector3.Distance(origin.localPosition, destination.localPosition);

        Debug.Log(origin.localPosition);
        Debug.Log(destination.localPosition);

        Debug.Log("dist= " + dist);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
