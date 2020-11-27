using System.Collections;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using System.Globalization;
using System.Text.RegularExpressions;

[RequireComponent(typeof(ControlPanel))]
public class RotationUI : MonoBehaviour
{
    public ManageInput manageInput;

    public TMP_InputField rotationInput;
    public Slider rotationSlider;
    
    public TextMeshProUGUI minText;
    public TextMeshProUGUI maxText;

    [SerializeField]
    private float rotation;
    [SerializeField]
    private float minRotation;
    [SerializeField]
    private float maxRotation;

    private ControlPanel controlPanel;

    void Start()
    {
        controlPanel = GetComponent<ControlPanel>();

        manageInput.Rotation = rotation;

        // --- update the UI  ----
        // Input
        rotationInput.text = rotation.ToString("0.0000");
        // Slider
        rotationSlider.minValue = minRotation;
        rotationSlider.maxValue = maxRotation;
        rotationSlider.value = rotation;
        // Text
        minText.text = minRotation.ToString();
        maxText.text = maxRotation.ToString();
        // --- --- ----
    }

    public void InputChanged(string s)
    {
        //warning.gameObject.SetActive(false);

        if (float.TryParse(s, out float f))
        {
            f = controlPanel.CheckMin(minRotation, f);
            f = controlPanel.CheckMax(maxRotation, f);

            SetRotation(f);
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


            unitPlaces = controlPanel.CheckMin(minRotation, unitPlaces);
            unitPlaces = controlPanel.CheckMax(maxRotation, unitPlaces);

            SetRotation(unitPlaces);
        }
    }

    /*
     * TODO: fix this =>When the slide is changed by script
     * this is called aguen by the slider onValueChanged
     */
    public void SliderChanged(float f)
    {
        SetRotation(f);

        controlPanel.SendDataToBLE("Rotation: " + f);
    }

    
    public void SetRotation(float f)
    {
        f = controlPanel.CheckMin(minRotation, f);
        f = controlPanel.CheckMax(maxRotation, f);

        rotation = f;

        rotationInput.text = f.ToString("0.0000");
        rotationSlider.value = f;

        manageInput.Rotation=  f;
    }
}
