using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrammeUIPanel : MonoBehaviour
{
    public RotatingArm rotatingArm;

    public void SetVoltage(float voltage){
        rotatingArm.Voltage = voltage;
    }
    
    public void SetAmperage(float amperage){
        rotatingArm.Amperage = amperage;
    }
}
