using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetaction2 : MonoBehaviour
{
    [HideInInspector]
    public bool isObjectStay;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "wood" || other.tag == "rubber" || other.tag == "steel")
        {
            isObjectStay = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "wood" || other.tag == "rubber" || other.tag == "steel")
        {
            isObjectStay = false;
        }
    }
}
