using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
public class ObjectDefaultPos : GrabbableEvents
{
    public WheelAttach[] wheelAttach;

    Vector3 DefaultPos;
    Quaternion DefaultRotation;

    void OnEnable()
    {
        DefaultPos = transform.position;
        DefaultRotation = transform.rotation;
    }
    public override void OnRelease()
    {
        if(!wheelAttach[0].isSnaped && !wheelAttach[1].isSnaped)
        {
            transform.position = DefaultPos;
            transform.rotation = DefaultRotation;
        }    
    }

    public void ResetTransform()
    {
        transform.position = DefaultPos;
        transform.rotation = DefaultRotation;
    }
}
