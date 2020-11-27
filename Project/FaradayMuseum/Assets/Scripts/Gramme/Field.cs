using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public Vector3 FieldVector { get; set; }
    // Start is called before the first frame update
    
    public void Invert()
    {
        FieldVector = -1 * FieldVector;

        transform.GetChild(0).localRotation = transform.GetChild(0).localRotation  * new Quaternion(0, 0, 180,0);
    }
}
