using BNG;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
public class LeverEventTable2 : MonoBehaviour
{
    public WinnigPromt winnigPrompt;
    [Space]
    public GrabbableHaptics OnOffHaptic;
    [Space]
    public Collider LeverGrabCollider;
    [Space]
    public Snap_Table2[] snapTable2;
    public TriggerDetaction2[] TriggerDetection;
    public CustomLever Lever;
    public UnityEvent leverDwounMoreActivitis_2;
    [Space]
    public GameObject LeverHighlight;
    public GameObject LeverDownArrow;

    [Space]
    [Range(0f, 2f)]
    public float threshold = .5f;

    [Space]
    [Header("This event will automatically perfomed when lever set to on")]
    public UnityEvent LeverOnEvent;

    [Space]
    [Header("This event will automatically performed when lever set to off")]
    public UnityEvent LeverOffEvent;

    bool isLeverON = false;

    private void OnEnable()
    {

        isLeverON = false;
    }

    private void Update()
    {
        if (snapTable2[0].isSnap && snapTable2[1].isSnap)
        {
            OnOffHaptic.currentGrabber = GetComponent<GrabbableHaptics>().currentGrabber;
            if (Lever.Angle >= Lever.MaxAngle - threshold && isLeverON)
            {
                OnOffHaptic.doHaptics(OnOffHaptic.currentGrabber.HandSide);

                foreach (Snap_Table2 st in snapTable2)
                {
                    st.RemoveSnapObject();
                }

                LeverOffEvent.Invoke();
                isLeverON = false;
            }

            if (Lever.Angle <= Lever.MinAngle + threshold && !isLeverON)
            {
                if (OnOffHaptic.currentGrabber != null)
                {
                    OnOffHaptic.doHaptics(OnOffHaptic.currentGrabber.HandSide);
                }

                foreach (Snap_Table2 st in snapTable2)
                {
                    st.DisbaleCollider();
                }

                isLeverON = true;
                LeverOnEvent.Invoke();
            }

            if (TriggerDetection[0].isObjectStay && TriggerDetection[1].isObjectStay && !isLeverON)
            {
                LeverGrabCollider.enabled = true;
                LeverHighlight.SetActive(true);
                LeverDownArrow.SetActive(true);
                leverDwounMoreActivitis_2.Invoke();
            }
            else
            {  
                if (LeverGrabCollider.enabled && !winnigPrompt.enabled)
                {
                    LeverDownArrow.SetActive(false);
                    LeverHighlight.SetActive(false);
                    LeverGrabCollider.enabled = false;
                }
                
            }
        }
    }
}

