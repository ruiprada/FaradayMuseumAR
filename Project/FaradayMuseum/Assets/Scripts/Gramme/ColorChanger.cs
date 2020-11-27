using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using System.Collections;

public class ColorChanger : MonoBehaviour
{

    float duration = 20.0f;
    private float t = 0;
    bool isReset = false;

    void Update()
    {
        ColorChangerr();
    }


    void ColorChangerr()
    {
        Color currentColor = GetComponent<Renderer>().material.color;

        float h, s, v;
        Color.RGBToHSV(currentColor, out h, out s, out v);
        float newS;
        newS = s + 1.0f;
        //Color nextColor = new Color(currentColor.r, currentColor.g * 0.5f, currentColor.b * 0.5f, currentColor.a);
        Color nextColor = Color.HSVToRGB(h, newS, v);


        GetComponent<Renderer>().material.color = Color.Lerp(currentColor, nextColor, t);

        if (t < 1)
        {
            t += Time.deltaTime / duration;
        }
    }
}