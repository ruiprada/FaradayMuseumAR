using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrammeManager : MonoBehaviour
{
    public GameObject magneticLines;
    public RotatingArm rotatingArm;
    public Magnet rightMagnet;
    public Magnet leftMagnet;

    private ColorChanger rightMagnetColor;
    private ColorChanger leftMagnetColor;

    private float previousTorque;
    // Start is called before the first frame update

    void Awake(){
        leftMagnet.IsNorth = false;
        rightMagnet.IsNorth = true;    

        rightMagnetColor = leftMagnet.GetComponent<ColorChanger>(); 
        leftMagnetColor = rightMagnet.GetComponent<ColorChanger>(); 
    }
    void Update() {
        if (rotatingArm.Torque != 0){
            magneticLines.gameObject.SetActive(true);
        }else{
            magneticLines.gameObject.SetActive(false);
        }

        // any Sign change (negative <-> positive)
        if(previousTorque * Mathf.Sign(rotatingArm.Torque) < 0){
            magneticLines.gameObject.SetActive(true);
            rightMagnet.ChangePolarity();
            leftMagnet.ChangePolarity();
            InvertMagneticField();
        }
        previousTorque = Mathf.Sign(rotatingArm.Torque);

        rightMagnetColor.SetColorStrength(Mathf.Abs(rotatingArm.Torque));
        leftMagnetColor.SetColorStrength(Mathf.Abs(rotatingArm.Torque));
    }
        public void InvertMagneticField(){
        foreach (Transform magneticRow in magneticLines.transform)
        {
            foreach (Transform item in magneticRow)
            {
                var texture = item.GetComponent<MagnetTexture>();
                if(texture){
                    texture.InvertMagnetTexture();
                }
            }
        }
    }
}
