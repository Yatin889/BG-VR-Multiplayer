using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using UnityEngine.Events;
public class OnGrab_ReleaseEvent : GrabbableEvents
{
    public GrabberEvent onGrab;
    public UnityEvent onRelease;

    public override void OnGrab(Grabber grabber)
    {
        if (onGrab != null)
        {
            onGrab.Invoke(grabber);

        }
    }

    public override void OnRelease()
    {
        if (onRelease != null)
        {
            onRelease.Invoke();
        }
    }
}
