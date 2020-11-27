using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CalculateShape))]
public class ManageInput : PhysicsConsts
{
    public Transform Ampule;
    public CoilsManager coilsManager;

    #region PRIVATE_VARIABLES

    private float intensity;  //Intensity of the eletrical current on the coils
    private float rotation; //angle of rotation of the ampoule in degrees
    private float tension; // tension of the eletrical current in the cathode ray

    private CalculateShape calculateShape;
    
    #endregion

    #region PUBLIC_FUNCTIONS

    #region GETS&&SETS

    public float Intensity
    {
        get { return intensity; }

        set
        {
            intensity = value;

            calculateShape.SetB(intensity);
            coilsManager.UpdateSize(intensity);
        }
    }

    public float Tension
    {
        get { return tension; }
        set
        {
            tension = value;

            calculateShape.SetV0(tension);
        }
    }

    public float Rotation
    {
        get { return rotation; }
        set
        {
            rotation = value;

            Vector3 temp = Ampule.rotation.eulerAngles;
            temp.z = rotation;
            Ampule.rotation = Quaternion.Euler(temp);

            //Ampule.eulerAngles = new Vector3(Ampule.eulerAngles.x, rotation, Ampule.eulerAngles.z);
            // Ampule.Rotate(0, 0.0f, rotation, Space.Self);

            calculateShape.SetAlpha(rotation);
        }
    }

    #endregion

    void Awake()
    {
        calculateShape = gameObject.GetComponent<CalculateShape>();
    }

    #endregion

   
}
