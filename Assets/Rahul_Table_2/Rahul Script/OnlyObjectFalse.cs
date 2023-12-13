using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyObjectFalse : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject objectToDisable;

    public void DisableObject()
    {
        // Disable the GameObject
        objectToDisable.SetActive(false);

        // Enable the collider component
        Collider collider = objectToDisable.GetComponent<Collider>();
        if (collider != null)
        {
            collider.enabled = true;
        }
    }
}


