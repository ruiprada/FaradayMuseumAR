using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticField : MonoBehaviour
{
    public Transform Magnets;

    public int numberOfFields;

    private float scaleFactor;
    // Start is called before the first frame update
    void Awake()
    {
        float offsetZ = Magnets.localScale.z / 2;
        float offsetY = Magnets.localScale.y / 2;
        scaleFactor = transform.parent.localScale.x;

        transform.localPosition = new Vector3(0, -offsetY, -offsetZ);

        foreach (Transform eachChild in transform)
        {
            if (eachChild.name == "MagneticField")
            {
                for(int i = 0; i<numberOfFields; i++)
                {
                    GameObject duplicate = Instantiate(eachChild.gameObject) as GameObject;
                    duplicate.transform.SetParent(gameObject.transform);
                    duplicate.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
                }
                Destroy(eachChild.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        float length = Magnets.localScale.y;
        float factor = 1.0f / (numberOfFields + 1);

        int i = 1;
        foreach (Transform tf in transform)
        {
            if(tf.tag == "Field")
            {
                float finalPosition = factor * i * length;
                tf.localPosition = new Vector3(0, finalPosition, 0);
                i++;
            }
        }
    }
}
