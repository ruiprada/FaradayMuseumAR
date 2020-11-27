using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticField : MonoBehaviour
{
    public Transform Magnets;

    public int numberOfFields;

    private Vector3 scaleFactor;
    // Start is called before the first frame update
    void Awake()
    {
        transform.position = Magnets.position;
        scaleFactor = new Vector3(Magnets.localScale.x, Magnets.localScale.y, Magnets.localScale.z);

        foreach (Transform eachChild in transform)
        {
            if (eachChild.name == "MagneticField")
            {
                for(int i = 0; i<numberOfFields; i++)
                {
                    GameObject duplicate = Instantiate(eachChild.gameObject) as GameObject;
                    duplicate.transform.SetParent(gameObject.transform);
                    duplicate.transform.localScale = scaleFactor;
                }
                Destroy(eachChild.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        float length = Magnets.localScale.x;
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
