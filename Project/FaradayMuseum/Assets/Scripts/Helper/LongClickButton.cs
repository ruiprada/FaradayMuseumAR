using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LongClickButton : Button, IPointerDownHandler, IPointerUpHandler
{ 
    public bool pointerDown;

    public new void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
    }

    public new void OnPointerUp(PointerEventData eventData)
    {
        pointerDown = false;
    }

    // Start is called before the first frame update
    new void Start()
    {
        pointerDown = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
