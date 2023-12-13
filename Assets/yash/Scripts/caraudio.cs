using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caraudio : MonoBehaviour
{
    public GameObject[] Wheels;
    public AudioSource audioSource;
    [Header("Sequence Wood, Rubber and Steel")]
    public AudioClip[] Clip;

    private void OnEnable()
    {
        Debug.Log("Onnn");
        foreach(GameObject obj in Wheels)
        {
            if(obj.tag == "Wood")
            {
                audioSource.clip = Clip[0];
            }
            else if(obj.tag == "Rubber")
            {
                audioSource.clip = Clip[1];
            }
            else if(obj.tag == "Steel")
            {
                audioSource.clip = Clip[2];
            }
        }
    }
}
