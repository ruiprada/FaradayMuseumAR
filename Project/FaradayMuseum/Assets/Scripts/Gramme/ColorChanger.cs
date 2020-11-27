using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{

    Material material;
    Color mainColor;
    float duration = 30.0f;
    private float t = 0;

    private float intensifier;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
        mainColor = GetComponent<Renderer>().material.color;
    }

    void Update()
    {
        ColorChangerr();
    }


    void ColorChangerr()
    {
        float h, s, v;
        //Debug.Log(mainColor);
        Color.RGBToHSV(mainColor, out h, out s, out v);
        float newS;
        newS = s + intensifier;
        Color nextColor = Color.HSVToRGB(h, newS, v);
        GetComponent<Renderer>().material.color = Color.Lerp(mainColor, nextColor, t);

        if (t < 1)
        {
            t += Time.deltaTime / duration;
        }
    }

    public void SetColorStrength(float s)
    {
        intensifier = s;
        //Debug.Log(intensifier);
    }
}