using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    Material material;
    public Color mainColor { get; set; }
    private float t = 0;
    private float colorStrength;
    public MagnetSettings settings;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        UpdateColor();
    }

    void UpdateColor()
    {
        //HSV is easier to adjust the color saturation (S)
        float h, s, v;
        Color.RGBToHSV(mainColor, out h, out s, out v);
        float newS;
        newS = s + (colorStrength * settings.intensifierMultiplier);
        Color nextColor = Color.HSVToRGB(h, newS, v);
        material.color = Color.Lerp(mainColor, nextColor, t);

        if (t < 1)
        {
            t += Time.deltaTime / settings.duration;
        }
    }

    public void SetColorStrength(float strength)
    {
        colorStrength = strength;
    }
}