﻿using System;
using UnityEngine;

public class VRGrab : MonoBehaviour
{
    public GameObject controller;
    public string axisName;
    public Vector3 holdPosition = new Vector3(0, -0.025f, 0.03f);
    public Vector3 holdRotation = new Vector3(0, 180, 0);

    private float triggerState = 0;
    public bool holdingPutter = false;
    private GameObject putter = null;

    void Update()
    {
        triggerState = Input.GetAxis(axisName);

        if (holdingPutter)
        {
            if (Input.GetButtonDown("DropPutter"))
            {
                Release();
            }
        }
    }

    private void Release()
    {
        putter.transform.parent = null;
        //putter.GetComponentInParent<BoxCollider>().enabled = true;
        Rigidbody rb = putter.GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.isKinematic = false;
    }

    void Grab(GameObject obj)
    {
        holdingPutter = true;
        putter = obj;

        putter.transform.parent = transform;

        putter.transform.localPosition = holdPosition;
        putter.transform.localEulerAngles = holdRotation;

        //putter.GetComponentInParent<BoxCollider>().enabled = false;
    }

    void Release(GameObject obj)
    {
        holdingPutter = false;
        putter = null;

        putter.transform.SetParent(null);

        Rigidbody rb = putter.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Putter"))
        {
            if (triggerState > 0.6f && !holdingPutter)
            {
                Grab(other.gameObject);
            }
        }
    }
}