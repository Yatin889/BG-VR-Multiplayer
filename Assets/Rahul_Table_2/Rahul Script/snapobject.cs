using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using UnityEngine.Events;

public class snapobject : MonoBehaviour
{
    public string Tag;
    [Space]
    [Header("")]
    public UnityEvent OnTriggerEvent;
    GameObject snap;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tag)
        {
            snap = other.gameObject;
          
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.GetComponent<Grabbable>().enabled = false;
           
            StartCoroutine(lerp());
        }
    }

    IEnumerator lerp()
    {
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime * .3f;

            snap.transform.position = Vector3.MoveTowards(snap.transform.position, transform.position, Time.deltaTime * .02f);         
         
            snap.GetComponent<Rigidbody>().isKinematic = false;
            snap.GetComponent<Grabbable>().enabled = true;

            OnTriggerEvent.Invoke();

            yield return null;
        }    
    }
}
