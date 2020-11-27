using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public bool IsNorth { get; set; }

    public Material NorthPole { get; set; }
    public Material SouthPole { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Polarity();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangePolarity()
    {
        IsNorth = !IsNorth;

        Polarity();

    }

    public void Polarity()
    {
        if (IsNorth)
        {
            GetComponentInChildren<TextMesh>().text = "N";
            GetComponent<Renderer>().material = NorthPole;
        }
        else
        {
            GetComponentInChildren<TextMesh>().text = "S";
            GetComponent<Renderer>().material = SouthPole;
        }
    }
}
