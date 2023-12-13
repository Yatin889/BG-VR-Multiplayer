using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class defaultposobj : GrabbableEvents
{

    Vector3 DefaultPos;
    Quaternion DefaultRotation;

    void OnEnable()
    {
        DefaultPos = transform.position;
        DefaultRotation = transform.rotation;
    }
    /*    public override void OnRelease()
        {
            transform.position = DefaultPos;
                transform.rotation = DefaultRotation;
        }*/
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Floor")
        {
            ResetTransform();
        }
    }
    public void ResetTransform()
    {
        transform.position = DefaultPos;
        transform.rotation = DefaultRotation;
        GetComponent<Collider>().enabled = true;
        GetComponent<Rigidbody>().isKinematic = true;
    }
}
