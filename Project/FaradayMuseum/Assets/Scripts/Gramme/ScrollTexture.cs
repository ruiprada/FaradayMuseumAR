﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTexture : MonoBehaviour
{

    public float scrollX = 0.5f;
    public float scrollY = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float offsetX = Time.time * scrollX;
        float offsetY = Time.time * scrollY;

        GetComponent<Renderer>().material.mainTextureScale = new Vector2(1, 1);
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(-offsetX, offsetY);
    }

    public void InvertTexture()
    {
        scrollX *= -1;
        scrollY *= -1;
    }
}
