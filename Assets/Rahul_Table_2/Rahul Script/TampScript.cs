using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TampScript : MonoBehaviour
{
    private int enteredObjectCount = 0;
    public GameObject obj;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("wood") || other.CompareTag("rubber") || other.CompareTag("steel"))
        {
            enteredObjectCount++;

            if (enteredObjectCount >= 2)
            {
                obj.SetActive(true);
            }
        }
    }

   /* private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("wood") || other.CompareTag("rubber") || other.CompareTag("steel"))
        {
            enteredObjectCount--;
            if (enteredObjectCount < 0)
            {
                enteredObjectCount = 0;
            }
        }
    }*/



}
