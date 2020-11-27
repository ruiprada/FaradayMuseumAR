using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ControlPanel : MonoBehaviour
{
    [SerializeField]
    private bool UIEnabled = false;

    public BLEManager BLEManager;
    public GameObject UI;
    //Warning
    public GameObject warning;
    public TextMeshProUGUI warningText;  
    
    public void OnButtonClick()
    {
        UIEnabled = !UIEnabled;

        UI.gameObject.SetActive(UIEnabled);
    }

    public IEnumerator WarningTheUsers(string s)
    {
        warning.SetActive(true);
        warningText.text = s;

        yield return new WaitForSeconds(1.5f);

        warning.SetActive(false);
    }

    public float CheckMin(float min, float f)
    {
        if (f < min)
        {
            StartCoroutine(WarningTheUsers("The min value is: " + min + "."));

            f = min;
        }
        return f;
    }

    public float CheckMax(float max, float f)
    {
        if (f > max)
        {
            StartCoroutine(WarningTheUsers("The max value is: " + max + "."));

            f = max;
        }
        return f;
    }

    public void SendDataToBLE(string s)
    {
        if (BLEManager.connectBLE == true)
        {
            BLEManager.MySendData(s);
        }
    }

        
}
