using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticForceLine : MonoBehaviour
{
    public Transform Magnets;
    public Transform RightMagnetPivot;
    public Transform LeftMagnetPivot;

    public GameObject arrowPrefab;

    public Material material;

    public int numberOfLines;

    public float scrollX = 0.5f;
    public float scrollY = 0f;

    private int previousLines;
    private float scaleFactor;

    void Start()
    {
        scaleFactor = transform.localScale.z;
        previousLines = numberOfLines;

        for (int j = 0; j < numberOfLines; j++)
        {
            GameObject go = new GameObject
            {
                name = "MagneticLine"
            };
            LineRenderer lineRenderer = go.AddComponent<LineRenderer>();
            lineRenderer.startWidth = 0.01f * scaleFactor;
            lineRenderer.endWidth = 0.01f * scaleFactor;
            lineRenderer.useWorldSpace = false;

            lineRenderer.GetComponent<Renderer>().material = material;

            go.transform.SetParent(gameObject.transform);

            GameObject arrow = Instantiate(arrowPrefab) as GameObject;
            foreach(Renderer renderer in arrow.GetComponentsInChildren<Renderer>())
            {
                renderer.GetComponent<Renderer>().material = material;
            }

            arrow.transform.SetParent(lineRenderer.transform);
            arrow.transform.Rotate(0, 90, 90, Space.Self);
            arrow.transform.localScale = new Vector3(0.01f* scaleFactor, 0.01f* scaleFactor, 0.01f * scaleFactor);
        }
    }

    void Update()
    {

        if(previousLines != numberOfLines)
        {
            previousLines = numberOfLines;

            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            for (int j = 0; j < numberOfLines; j++)
            {
                GameObject go = new GameObject
                {
                    name = "MagneticLine"
                };
                LineRenderer lineRenderer = go.AddComponent<LineRenderer>();
                lineRenderer.startWidth = 0.05f * scaleFactor;
                lineRenderer.endWidth = 0.05f * scaleFactor; 
                lineRenderer.useWorldSpace = false;
                go.transform.SetParent(gameObject.transform);
            }
        }

        float length = Magnets.localScale.x * scaleFactor + (0.1f);

        //float length_aux = Vector3.Distance(RightMagnet.position, LeftMagnet.position);
        float factor = 1.0f / (numberOfLines + 1);

        int i = 1;
        foreach (Transform tf in transform)
        {
            LineRenderer tempLineRenderer = tf.gameObject.GetComponent<LineRenderer>();
            float finalPosition = factor * i * length;
            tempLineRenderer.SetPosition(0, new Vector3(LeftMagnetPivot.position.x * scaleFactor, 0, finalPosition));
            tempLineRenderer.SetPosition(1, new Vector3(RightMagnetPivot.position.x * scaleFactor, 0, finalPosition));

            float offsetX = Time.time * scrollX;
            float offsetY = Time.time * scrollY;

            //tempLineRenderer.GetComponent<Renderer>().material.mainTextureScale = new Vector2(length * 2, 1);
            tempLineRenderer.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(-offsetX, offsetY);

            foreach (Transform arrow in tf.gameObject.GetComponent<LineRenderer>().transform)
            {
                arrow.localPosition = new Vector3(0, 0, finalPosition);
            }
            i++;
        }
    }
   
}
