using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using System;

public class DefaultPosObj : MonoBehaviour
{
    public GrabbableUnityEvents grabbableUnityEvents;
    Vector3 DefaultPos;
    public GameObject Obj;
    Quaternion DefaultRotation;
    public bool IsOn;

    void Start()
    {
        grabbableUnityEvents = GetComponent<GrabbableUnityEvents>();
        grabbableUnityEvents.onGrab.AddListener(grabEnvent);
        grabbableUnityEvents.onRelease.AddListener(releaseEnvent);
        DefaultPos = Obj.transform.position;
        DefaultRotation = Obj.transform.rotation;
    }

    private void releaseEnvent()
    {
        Obj.GetComponent<Rigidbody>().isKinematic = true;
        IsOn = true;
    }

    private void grabEnvent(Grabber arg0)
    {
        Obj.GetComponent<Rigidbody>().isKinematic = false;
        IsOn = false;
    }

    void Update()
    {
        if(IsOn)
        {
            Obj.transform.position = Vector3.Lerp(Obj.transform.position, DefaultPos, 10 * Time.deltaTime);
            Obj.transform.rotation = DefaultRotation;
        }
    }

    public void Lerp()
    {
        IsOn = true;
    }
    public void LerpFalse()
    {
        IsOn = false;
    }
}
