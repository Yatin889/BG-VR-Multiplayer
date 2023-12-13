using UnityEngine;
using BNG;
public class HapticContinue : MonoBehaviour
{
    private bool isHaptic;
    public GrabbableHaptics hapticData;
    void Update()
    {
        if (isHaptic)
        {
            if (!hapticData.currentGrabber) return;
            hapticData.doHaptics(hapticData.currentGrabber.HandSide);
        }
    }
    public void SendHapticContineous()
    {
        isHaptic = true;
    }
    public void StopHapticCountineous()
    {
        isHaptic = false;
    }

    public void SingleHaptcCall()
    {
        if (hapticData.currentGrabber)
            hapticData.doHaptics(hapticData.currentGrabber.HandSide);
    }
}

