using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using Unity.VisualScripting;

public class WheelAttach : MonoBehaviour
{
    public CarMove carMove;
    [Space]
    public GameObject HighlightWheelParent;
    [Space]
    public GameObject[] Wheels;

    [HideInInspector]
    public GameObject AttachedWheel;

    //[HideInInspector]
    public bool isSnaped, isComplete;

    public Material DefaultMaterial;

    public GrabbableHaptics SnapHaptic;

    private void OnEnable()
    {
        isSnaped = false;
        //DefaultMaterial = Wheels[0].GetComponent<Renderer>().material;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(Wheels[1].transform.childCount == 0 && Wheels[2].transform.childCount == 0)
        {
            if (other.tag == "Wood")
            {
                carMove.Wood = true;
                StartCoroutine(LerpToWheel(other.gameObject));
            }
            else if (other.tag == "Steel")
            {
                carMove.Steel = true;
                StartCoroutine(LerpToWheel(other.gameObject));
            }
            else if (other.tag == "Rubber")
            {
                carMove.Rubber = true;
                StartCoroutine(LerpToWheel(other.gameObject));
            }
        } 
    }
    IEnumerator LerpToWheel(GameObject obj)
    {
        HighlightWheelParent.SetActive(false);
        
        AttachedWheel = obj;
        
        GrabbableHaptics gh = obj.GetComponent<GrabbableHaptics>();
        SnapHaptic.currentGrabber = gh.currentGrabber;

        if (SnapHaptic.currentGrabber)
        {
            SnapHaptic.doHaptics(SnapHaptic.currentGrabber.HandSide);
        }
       
        foreach (GameObject wheel in Wheels)
        {
            if(wheel.GetComponent<Collider>())
            {
                wheel.GetComponent<Collider>().enabled = false; 
            }
        }

        isSnaped = true;

        Grabbable grabbable = obj.GetComponent<Grabbable>();

        if(grabbable.BeingHeld)
        {
            grabbable.DropItem(grabbable.HeldByGrabbers[0]);
        }
        
        obj.transform.parent = transform;
        obj.GetComponent<Rigidbody>().isKinematic = true;
        obj.GetComponent<Collider>().enabled = false;
       
        float t = 0;
       
        while (t < 1)
        {
            t += Time.deltaTime * 4;

            obj.transform.position = Vector3.Lerp(obj.transform.position, transform.position, Time.deltaTime * 15f);
            obj.transform.eulerAngles = transform.eulerAngles;

            if (t >= 1f && isSnaped)
            {
                SnapHaptic.currentGrabber = null;
                foreach(GameObject wheel in Wheels)
                { 
                    wheel.GetComponent<Renderer>().material = obj.GetComponent<Renderer>().material;
                    wheel.tag = obj.tag;
                 
                    obj.GetComponent<Collider>().enabled = true;

                    if (wheel.GetComponent<WheelAttach>())
                    {
                        wheel.GetComponent<WheelAttach>().isComplete = true;
                    }
                    //isComplete = true;
                }

                isSnaped = false;
                // obj.GetComponent<ObjectDefaultPos>().ResetTransform();
            }

            yield return null;
        }
    }
    public void ResetMaterial()
    {
        if (AttachedWheel && AttachedWheel.GetComponent<Grabbable>().BeingHeld)
        {
            foreach (GameObject wheel in Wheels)
            {
                wheel.GetComponent<Renderer>().material = DefaultMaterial;

                HighlightWheelParent.SetActive(true);

                if(wheel.GetComponent<WheelAttach>())
                {
                    wheel.GetComponent<WheelAttach>().isComplete = false;
                }    
            }
        }    
    }
    public void StartPorcess()
    {
        if(AttachedWheel)
        {
            foreach (GameObject wheel in Wheels)
            {
                if (wheel.GetComponent<WheelAttach>())
                {
                    wheel.GetComponent<WheelAttach>().isComplete = false;
                }
            }
            AttachedWheel.SetActive(false);
        }       
    }   
    
    public void EndProcess()
    {
        foreach (GameObject wheel in Wheels)
        {
            wheel.GetComponent<Renderer>().material = DefaultMaterial;
            wheel.tag = "Untagged";

            HighlightWheelParent.SetActive(true);
    
            if(wheel.GetComponent<WheelAttach>())
            {
                wheel.GetComponent<WheelAttach>().isComplete = false;
            }
        }
    }
}
