using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Magnet Settings")]
public class MagnetSettings : ScriptableObject
{
    public float intensifierMultiplier;
    public float duration = 15.0f;
    public Color northPoleColor = new Color(1f, 0.99f, 0.99f, 1.0f);
    public Color southPoleColor = new Color(0.99f, 0.99f, 1.0f,  1.0f);
}
