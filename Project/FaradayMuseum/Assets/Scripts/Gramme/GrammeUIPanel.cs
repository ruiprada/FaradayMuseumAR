using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrammeUIPanel : MonoBehaviour
{
    public RotatingArm rotatingArm;

    public InputField inputAmperage;
    public InputField inputVoltage;

    void Start() {
        SetAmperage(inputAmperage.text);
        SetVoltage(inputVoltage.text);
    }

    public void SetVoltage(string voltageTxt){
        float voltage = float.Parse(voltageTxt);
        rotatingArm.Voltage = voltage;
    }
    public void SetVoltage(float voltage){
        rotatingArm.Voltage = voltage;
    }

    public void SetAmperage(string amperageTxt){
        float amperage = float.Parse(amperageTxt);
        rotatingArm.Amperage = amperage;
    }
    public void SetAmperage(float amperage){
        rotatingArm.Amperage = amperage;
    }

    public void IncrementVoltage(){
        float voltage = rotatingArm.Voltage + 1;
        inputVoltage.text = voltage.ToString();
        SetVoltage(voltage);
    }
    public void DecrementVoltage(){
        float voltage = rotatingArm.Voltage - 1;
        inputVoltage.text = voltage.ToString();
        SetVoltage(voltage - 1);
    }


    public void IncrementAmperage(){
        float amperage = rotatingArm.Amperage + 1;
        inputAmperage.text = amperage.ToString();
        SetAmperage(amperage);
    }
    public void DecrementAmperage(){
        float amperage = rotatingArm.Amperage - 1;
        inputAmperage.text = amperage.ToString();
        SetAmperage(amperage);
    }
}
