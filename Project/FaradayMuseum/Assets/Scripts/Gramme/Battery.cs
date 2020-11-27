using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public float speed;
    public float Voltage { get; set; }

    public Field rightField;
    public Field leftField;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(0, speed * Time.deltaTime, 0);
    }

    public void Rotate()
    {
        rightField.Invert();
        leftField.Invert();
        // rotatingArm.InvertTexture();
        animator.SetTrigger("rotate");
    }
}
