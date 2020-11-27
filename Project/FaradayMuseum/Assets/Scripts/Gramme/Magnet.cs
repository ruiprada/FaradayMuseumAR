using UnityEngine;

public class Magnet : MonoBehaviour
{
    public bool IsNorth { get; set; }
    ColorChanger colorChanger;
    public MagnetSettings settings;

    // Start is called before the first frame update
    void Start()
    {
        colorChanger = GetComponent<ColorChanger>();
        UpdatePolarity();
    }

    public void ChangePolarity(){
        IsNorth = !IsNorth;
        UpdatePolarity();
    }

    public void UpdatePolarity()
    {
        colorChanger.mainColor = IsNorth ? settings.northPoleColor : settings.southPoleColor;
    }
}
