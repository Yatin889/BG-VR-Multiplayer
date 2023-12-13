using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using UnityEngine.Events;
public class CustomGrabbableEvents : GrabbableEvents
{
    public UnityEvent OnGrabEvent;
    public UnityEvent OnReleaseEvent;
    public UnityEvent onBecomesClosestGrabbable;
    public override void OnGrab(Grabber grabber)
    {
        OnGrabEvent.Invoke();
    }
    public override void OnRelease()
    {
        OnReleaseEvent.Invoke();
    }
    public override void OnBecomesClosestGrabbable(ControllerHand touchingHand)
    {
        base.OnBecomesClosestGrabbable(touchingHand);

        if (onBecomesClosestGrabbable != null)
        {
            onBecomesClosestGrabbable.Invoke();
        }
    }
}
