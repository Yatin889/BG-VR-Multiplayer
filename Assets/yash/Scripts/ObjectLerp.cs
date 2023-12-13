using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class ObjectLerp : MonoBehaviour
{
    [HideInInspector]
    public bool isTure;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Rubber")
        {
            Grabbable Grab1 = other.GetComponent<Grabbable>();

            StartCoroutine(LerpToWheel(other.gameObject, Grab1));
        }
       
        if (other.tag == "Steel")
        {
            Grabbable Grab2 = other.GetComponent<Grabbable>();

            StartCoroutine(LerpToWheel(other.gameObject, Grab2));
        }
      
        if (other.tag == "Wood")
        {
            Grabbable Grab3 = other.GetComponent<Grabbable>();

            StartCoroutine(LerpToWheel(other.gameObject, Grab3));
        }
    }
    IEnumerator LerpToWheel(GameObject obj, Grabbable _grab)
    {
        isTure = true;

        if (_grab.BeingHeld)
        {
            _grab.DropItem(_grab.HeldByGrabbers[0]);
        }

        obj.GetComponent<Collider>().enabled = false;
        obj.GetComponent<Rigidbody>().isKinematic = true;

        transform.tag = obj.tag;

        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime * .4f;

            obj.transform.position = Vector3.MoveTowards(obj.transform.position, transform.position, Time.deltaTime * 1f);
            obj.transform.eulerAngles = new Vector3(-90, -90, 90);

            if(t > .5f)
            {
                obj.GetComponent<defaultposobj>().ResetTransform();
            }

            yield return null;
        }
    }
}

