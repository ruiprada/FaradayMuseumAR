using System.Collections;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using System.Globalization;
using System.Text.RegularExpressions;

[RequireComponent(typeof(ControlPanel))]
public class TensionUI : MonoBehaviour
{
    public ManageInput manageInput;

    public TMP_InputField tensionInput;
    public Slider tensionSlider;

    public TextMeshProUGUI minText;
    public TextMeshProUGUI maxText;

    [SerializeField]
    private float tension;
    [SerializeField]
    private float minTension;
    [SerializeField]
    private float maxTension;

    private ControlPanel controlPanel;

    void Start()
    {
        controlPanel = GetComponent<ControlPanel>();

        manageInput.Tension = tension;

        // --- update the UI  ----
        // Input
        tensionInput.text = tension.ToString("0.0000");
        // Slider
        tensionSlider.minValue = minTension;
        tensionSlider.maxValue = maxTension;
        tensionSlider.value = tension;
        // Text
        minText.text = minTension.ToString();
        maxText.text = maxTension.ToString();
        // --- --- ----
    }

    public void InputChanged(string s)
    {
        //warning.gameObject.SetActive(false);

        if (float.TryParse(s, out float f))
        {
            f = controlPanel.CheckMin(minTension, f);
            f = controlPanel.CheckMax(maxTension, f);

            SetTension(f);
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


            unitPlaces = controlPanel.CheckMin(minTension, unitPlaces);
            unitPlaces = controlPanel.CheckMax(maxTension, unitPlaces);

            SetTension(unitPlaces);
        }
    }

    /*
     * TODO: fix this =>When the slide by the input this is 
     * called aguen by the slider onValueChanged
     */
    public void SliderChanged(float f)
    {
        SetTension(f);

        controlPanel.SendDataToBLE("Tension: " + f);
    }

    public void SetTension(float f)
    {
        f = controlPanel.CheckMin(minTension, f);
        f = controlPanel.CheckMax(maxTension, f);

        tension = f;

        tensionInput.text = f.ToString("0.0000");
        tensionSlider.value = f;

        manageInput.Tension = f;
    }
}
