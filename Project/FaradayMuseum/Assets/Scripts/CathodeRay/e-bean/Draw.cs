using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//code based on https://forum.unity.com/threads/linerenderer-to-create-an-ellipse.74028/


[RequireComponent(typeof(LineRenderer))]
public class Draw : MonoBehaviour
{


    #region PRIVATE_VARIABLES
    [SerializeField]
    private GameObject Ampule;

    [SerializeField]
    private Color defaultColor;
    [SerializeField]
    private Color augementedColor;
    private Color augementedColor_Lock;

    private float ampuleRadius = 0.155f;

    private int numberOfVertices = 400;
    private float radius = 0.2f;
    
    private float lineWidthMultiplier = 0.2f;
    private float lineStartWidth = 0.02f;
    private float lineEndWidth = 0.02f;
    
    private LineRenderer lineRenderer;
    private Renderer renderer;
    #endregion

    void Awake()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();

        lineRenderer.positionCount = numberOfVertices;
        lineRenderer.useWorldSpace = false;

        lineRenderer.widthMultiplier = lineWidthMultiplier;
        lineRenderer.startWidth = lineStartWidth;
        lineRenderer.endWidth = lineEndWidth;

        renderer = GetComponent<Renderer>();
        renderer.material.SetFloat("_Radius", ampuleRadius);
        renderer.material.SetColor("_AugmentedColor", defaultColor);
        renderer.material.SetColor("_AugmentedColor", augementedColor);

        augementedColor_Lock = augementedColor;

        // Connect to ARButton event
        ShowARButton.OnARButtonClicked += UpdateColor;
    }

    private void Update()
    {
        //Global position of Ampule
        //necessary to be in Updated because ampilue positon changes due to AR
        List<Vector4> ampuleWorldPos = new List<Vector4>();
       
        ampuleWorldPos.Add(new Vector4(Ampule.transform.position.x,
            Ampule.transform.position.y, Ampule.transform.position.z, 1));

        renderer.material.SetVectorArray("_AmpulePos", ampuleWorldPos);
        
        //renderer.material.SetColor("_AugmentedColor", am)
    }


    public void DrawLine(double alpha)
    {
        lineRenderer.loop = false;

        //First point
        lineRenderer.SetPosition(0, new Vector3(0, 0, 0));

        // Second point
        float k = 0.105f;
        if(alpha == 0)
        {
            // z(t) = -V0 * t, (z(t) < 0) e x(t) = y(t) = 0 
            lineRenderer.SetPosition(1, new Vector3(0, 0, -k));
        }
        else
        {
            // z(t) = V0 * t, (z(t) > 0) e x(t) = y(t) = 0
            lineRenderer.SetPosition(1, new Vector3(0, 0, k));
        }

    }

    public void DrawCircle()
    {
        float x;
        float y;
        float z = 0;

        float angle = 0f;

        // This is stupid but it's how it works
        if (radius <= 1)
        {
            numberOfVertices = 40;
        }

        // One more point so the last one be equal to the first one
        lineRenderer.positionCount = numberOfVertices + 1;
        lineRenderer.loop = true;

        /*
         *  x(t) = R * (1 - cos(w * t)) 
         *  y(t) = R * sen(w * t)
         *  z(t) = 0 
         */

        for (int i = 0; i < (numberOfVertices + 1); i++)
        {
            //x = (float) (Math.Sin((Math.PI / 180) * angle) * radius);
            //y = (float) (Math.Cos((Math.PI / 180) * angle) * radius);

            x = (float) (radius * (1 - Math.Cos((Math.PI / 180) * angle)));
            y = (float) (radius * (Math.Sin((Math.PI / 180) * angle)));

            lineRenderer.SetPosition(i, new Vector3(z, x, y)); //new Vector3(y, z, x)

            angle += (360f / numberOfVertices);
        }
    }

    public void DrawSpiral(double alpha, double V0, double T, double W)
    {
        lineRenderer.loop = false;

        float x, y, z;
        float angle = 0f;

        // One more point so the last one be equal to the first one
        lineRenderer.positionCount = numberOfVertices + 1;

        /*
         * x(t) = R * sen(alpha) * (1 - cos(w * t))
         * y(t) = R * sen(alpha) * sen(w * t)
         * z(t) = v0 * t * cos(alpha)
         */

        for (int i = 0; i < (numberOfVertices + 1); i++)
        {
            x = (float) (radius * Math.Sin(alpha) * (1 - Math.Cos(W * ((Math.PI / 180) * angle))));
            y = (float) (radius * Math.Sin(alpha) * Math.Sin(W * ((Math.PI / 180) * angle)));
            z = (float) -(V0 * ((Math.PI / 180) * angle) * Math.Cos(alpha));

            lineRenderer.SetPosition(i, new Vector3(z, x, y));

            angle += (float) ( (360f * T) / numberOfVertices);  
        }
    }

    private void UpdateColor(bool showAR)
    {
        if (showAR) {
            //show the continus of the line
            augementedColor = augementedColor_Lock;
            renderer.material.SetColor("_AugmentedColor", augementedColor);
        }
        else
        {
            //Hide the line
            augementedColor.a = 0;
            renderer.material.SetColor("_AugmentedColor", augementedColor);
        }
    }

    //Always disable
    private void OnDisable()
    {
        ShowARButton.OnARButtonClicked -= UpdateColor;
    }

    #region GETS&SETS

    public int NumberOfVertices
    {
        get { return numberOfVertices; }
        set {
            numberOfVertices = value;

            lineRenderer.positionCount = numberOfVertices;
        }
    }

    public float Radius
    {
        get { return radius; }
        set { radius = value; }
    }

    public float LineWidthMultiplier
    {
        get { return lineWidthMultiplier; }
        set {
            lineWidthMultiplier = value;

            lineRenderer.widthMultiplier = lineWidthMultiplier;
        }
    }

    public float LineStartWidth
    {
        get { return lineStartWidth; }
        set { lineStartWidth = value; }
    }

    public float LineEndWidth
    {
        get { return lineEndWidth; }
        set { lineEndWidth = value; }
    }

    public Material UsedMaterial
    {
        get { return lineRenderer.material; }
        set { lineRenderer.material = value; }
    }

    #endregion
}
