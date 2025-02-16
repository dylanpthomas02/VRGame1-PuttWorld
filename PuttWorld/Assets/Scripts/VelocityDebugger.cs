﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityDebugger : MonoBehaviour
{
    [SerializeField]
    private float maxVelocity = 20f;

    void Update()
    {
        GetComponent<Renderer>().material.color = ColorBasedOnVelocity();
        
    }

    private Color ColorBasedOnVelocity()
    {
        float velocity = GetComponent<Rigidbody>().velocity.magnitude;

        return Color.Lerp(Color.green, Color.red, velocity / maxVelocity);
    }
}
