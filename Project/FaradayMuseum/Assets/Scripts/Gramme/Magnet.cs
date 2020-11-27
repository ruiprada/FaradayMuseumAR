using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public bool IsNorth { get; set; }

    private Color NorthPole = new Color(0, 1, 100);
    private Color SouthPole = new Color(240, 1, 100);

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
            // GetComponentInChildren<TextMesh>().text = "N";
            GetComponent<Renderer>().material.color = NorthPole;
        }
        else
        {
            // GetComponentInChildren<TextMesh>().text = "S";
            GetComponent<Renderer>().material.color = SouthPole;
        }
    }
}
