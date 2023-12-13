using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class HapticSignal : GrabbableEvents
{
    [Range(0f, 1f)]
    public float amp = 0.1f;
    public float duration = 0.1f;

    Grabber interactableLeftHand;
    Grabber interactableRightHand;

	public void HapticLeft()
	{
        if(interactableLeftHand != null)
        {


            input.VibrateController(0.1f, 0.1f, 0.1f, interactableLeftHand.HandSide);

        }


    }

    public void HapticRight()
    {
        if (interactableRightHand != null)
        {


            input.VibrateController(0.1f, 0.1f, 0.1f, interactableRightHand.HandSide);

        }


    }

}
