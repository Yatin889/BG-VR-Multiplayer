using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using BNG;
public class Snap_Table2 : MonoBehaviour
{
    public GrabbableHaptics SnapHaptic;
    public TriggerDetaction2 TD;
    [HideInInspector]
    public bool isSnap, isObjectStay;

    [HideInInspector]
    public GameObject CurrentObject;

    [HideInInspector]
    public bool isWood, isSteel, isRubber;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "wood" || other.tag == "rubber" || other.tag == "steel")
        {
            if (transform.childCount > 1) return;

            SnapHaptic.currentGrabber = other.GetComponent<GrabbableHaptics>().currentGrabber;
            
            if(SnapHaptic.currentGrabber)
            {
                SnapHaptic.doHaptics(SnapHaptic.currentGrabber.HandSide);
            }

            if(other.tag == "wood")
            {
                isWood = true;
            }
            else if(other.tag == "rubber")
            {
                isRubber = true;
            }
            else if(other.tag == "steel")
            {
                isSteel = true;
            }

            CurrentObject = other.gameObject;

            isSnap = true;
            isObjectStay = true;

            /////////// Enable kinamtic...
            other.GetComponent<Rigidbody>().isKinematic = true;
            
            /////////// Acess Grababble Script from wood, rubber and steel...
            Grabbable grabbable = other.GetComponent<Grabbable>();

            if (grabbable.BeingHeld)
            {
                grabbable.DropItem(grabbable.HeldByGrabbers[0]);
            }      

            /////////// Set Parent...
            other.transform.parent = transform;

            /////////// Set Position and Rotation...
            other.transform.position = transform.position;
            other.transform.rotation = transform.rotation;

            StartCoroutine(EnableFunction(other.gameObject, grabbable));
        }
    }
    IEnumerator EnableFunction(GameObject OBJ, Grabbable _grabbable)
    {
        OBJ.GetComponent<ObjectPosReset>().Highlight.SetActive(false);
     
        yield return new WaitForSeconds(.1f);
   
        /////////// Enabable again kinamtic and disable collider for static object...
        OBJ.GetComponent<Rigidbody>().isKinematic = true;
        OBJ.GetComponent<Collider>().enabled = false;

        /////////// Set Position and Rotation for backup...
        OBJ.transform.position = transform.position;
        OBJ.transform.rotation = transform.rotation;

        yield return new WaitForSeconds(2f);

        /////////// Disable child game object...
        transform.GetChild(0).gameObject.SetActive(false);
        SnapHaptic.currentGrabber = null;

        /////////// Enable Collider...
        OBJ.GetComponent<Collider>().enabled = true;

        /////////// Enable Animator...
        OBJ.GetComponent<Animator>().enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "wood" || other.tag == "rubber" || other.tag == "steel")
        {
            isSnap = false;
            isObjectStay = false;
        }
    }
    public void DisbaleCollider()
    {
        CurrentObject.GetComponent<Collider>().enabled = false;
        isObjectStay = false;
    }

    public void PlayAnimation()
    {
        TD.isObjectStay = false;

        CurrentObject.GetComponent<Animator>().applyRootMotion = false;
        CurrentObject.GetComponent<Animator>().SetBool("Play", true);
        CurrentObject.GetComponent<AudioSource>().Play();
    }

    public void RemoveSnapObject()
    {
        CurrentObject.GetComponent<Animator>().SetBool("Play", false);
        isSnap = false;
        isObjectStay = false;
        CurrentObject = null;

        FalseBoolean();
    }

    public void FalseBoolean()
    {
        isWood = false;
        isRubber = false;
        isSteel = false;
    }
}
