using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    float playerMovingSpeed = 20f;

    void FixedUpdate()
    {
        transform.Translate(Input.acceleration.x * playerMovingSpeed * Time.deltaTime,
                            Input.acceleration.y * playerMovingSpeed * Time.deltaTime, 0);
    }

}
