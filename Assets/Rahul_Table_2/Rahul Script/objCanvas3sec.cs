using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objCanvas3sec : MonoBehaviour
{
  
    public GameObject objectToActivate;
    
    public void onGrab(bool isOn)
    {
        if (isOn)
        {
            StartCoroutine(ActivateObjectAfterDelay());
        }
        else
        {
            objectToActivate.SetActive(false);
        }
    }

    private IEnumerator ActivateObjectAfterDelay()
    {
        // Set the object to active
        objectToActivate.SetActive(true);

        // Wait for another 3 seconds
        yield return new WaitForSeconds(3f);

        // Set the object back to inactive
        objectToActivate.SetActive(false);
    }
}


