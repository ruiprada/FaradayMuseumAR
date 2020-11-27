using System.Collections;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using System.Globalization;
using System.Text.RegularExpressions;

[RequireComponent(typeof(ControlPanel))]
public class IntensityUI : MonoBehaviour
{
    public ManageInput manageInput;

    public TMP_InputField intensityInput;
    public Slider intensitySlider;

    public TextMeshProUGUI minText;
    public TextMeshProUGUI maxText;

    [SerializeField]
    private float intensity;
    [SerializeField]
    private float minIntensity;
    [SerializeField]
    private float maxIntensity;

    private ControlPanel controlPanel;

    void Start()
    {
        controlPanel = GetComponent<ControlPanel>();

        manageInput.Intensity = intensity;

        // --- update the UI  ----
        // Input
        intensityInput.text = intensity.ToString("0.0000");
        // Slider
        intensitySlider.minValue = minIntensity;
        intensitySlider.maxValue = maxIntensity;
        intensitySlider.value = intensity;
        // Text
        minText.text = minIntensity.ToString();
        maxText.text = maxIntensity.ToString();
        // --- --- ----
    }

    public void InputChanged(string s)
    {
        //warning.gameObject.SetActive(false);

        if (float.TryParse(s, out float f))
        {
            f = controlPanel.CheckMin(minIntensity, f);
            f = controlPanel.CheckMax(maxIntensity, f);

            SetIntensity(f);
        }
        else
        {
            //for some reason this string is not a float
            var sSplited = s.Split("."[0]);

            float unitPlaces = float.Parse(sSplited[0]);
            float aux = float.Parse(sSplited[1]);

            float decimalPlaces = 0;
            if (sSplited[1].Length == 1)
            {
                decimalPlaces = aux / 10f;
            }
            else if (sSplited[1].Length == 2)
            {
                decimalPlaces = aux / 100f;
            }
            else if (sSplited[1].Length == 3)
            {
                decimalPlaces = aux / 1000f;
            }
            else if (sSplited[1].Length == 4)
            {
                decimalPlaces = aux / 10000f;
            }
            else
            {
                StartCoroutine(controlPanel.WarningTheUsers("The max number of decimal places are 4."));
            }
            unitPlaces = unitPlaces + decimalPlaces;


            unitPlaces = controlPanel.CheckMin(minIntensity, unitPlaces);
            unitPlaces = controlPanel.CheckMax(maxIntensity, unitPlaces);

            SetIntensity(unitPlaces);
        }
    }


    /*
     * TODO: fix this =>When the slide by the input this is 
     * called aguen by the slider onValueChanged
     */
    public void SliderChanged(float f)
    {
        SetIntensity(f);

        controlPanel.SendDataToBLE("Intensity: " + f);
    }

    public void SetIntensity(float f)
    {
        f = controlPanel.CheckMin(minIntensity, f);
        f = controlPanel.CheckMax(maxIntensity, f);

        intensity = f;

        intensityInput.text = f.ToString("0.0000");
        intensitySlider.value = f;

        manageInput.Intensity = f;
    }
}
