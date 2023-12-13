using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionControl : MonoBehaviour
{
 
    public GameObject myObject;
    public float switchInterval = 1.0f; // Time in seconds between enabling and disabling

    private void Start()
    {
        StartCoroutine(SwitchObject());
    }

    IEnumerator SwitchObject()
    {
        while (true)
        {
            myObject.SetActive(true);
            yield return new WaitForSeconds(switchInterval);
            myObject.SetActive(false);
            yield return new WaitForSeconds(switchInterval);
        }
    }

 
}



