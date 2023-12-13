using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class OncollisionHaptic : MonoBehaviour
{
    public HapticContinue hapticCountinueReference;
    public bool isRub = false;
    public Collider targetCollider;
    Rigidbody rb;
    public GrabbableHaptics grabbableHaptic;
    public float frequencyValueOfHaptic;
    float CurrentFrequencyValue;
    float CurrentAmplitudeValue;
    public float AmplitudeValueOfHaptic;
    public float time;
    public GameObject objToBeInstantiate;
    public GameObject AntModeButton;
    public GameObject[] objToBeDestroyed;
    public GameObject IdleAntModeButton;

    public GameObject shaderPlane;

    Vector3 lastVelocity = Vector3.zero;

    void Start()
    {
         CurrentFrequencyValue = GetComponent<GrabbableHaptics>().VibrateFrequency;
         CurrentAmplitudeValue = GetComponent<GrabbableHaptics>().VibrateAmplitude;
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionStay(Collision collision)
    {


        if (isRub && collision.collider == targetCollider && GetComponent<OncollisionHaptic>().enabled)
        {

            grabbableHaptic.GetComponent<GrabbableHaptics>().VibrateFrequency = frequencyValueOfHaptic;
            grabbableHaptic.GetComponent<GrabbableHaptics>().VibrateAmplitude = AmplitudeValueOfHaptic;


            /*  destroyed();*/

            //////for shader appear
            if (rb.velocity.magnitude > 0.5f)
            {
                hapticCountinueReference.SendHapticContineous();
                shaderPlane.SetActive(true);
            }
            if (rb.velocity.magnitude < 0.1f)
            {
                hapticCountinueReference.StopHapticCountineous();
                shaderPlane.SetActive(false);
            }
            /////for instantiate object after magnitude will set upto 2
            if (rb.velocity.magnitude > 1f)
            {
                StartCoroutine(Instantiate());
            }
        }
        else
        {
            hapticCountinueReference.StopHapticCountineous();
        }

        lastVelocity = rb.velocity;

       // Debug.Log(rb.velocity.magnitude);
    }

    private void OnCollisionExit(Collision collision)
    {
        shaderPlane.SetActive(false);
        grabbableHaptic.GetComponent<GrabbableHaptics>().VibrateFrequency = CurrentFrequencyValue;
        grabbableHaptic.GetComponent<GrabbableHaptics>().VibrateAmplitude = CurrentAmplitudeValue;
        hapticCountinueReference.StopHapticCountineous();
    }

    IEnumerator Instantiate()
    {
        yield return new WaitForSeconds(time);
        objToBeInstantiate.SetActive(true);
        AntModeButton.SetActive(true);
        IdleAntModeButton.SetActive(false);
    }

    public void destroyed()
    {
        for (int i = 0; i < objToBeDestroyed.Length; i++)
        {
            objToBeDestroyed[i].SetActive(false);
        }
        /* canvas1.SetActive(false);
         canvas2.SetActive(false);*/
    }
}
