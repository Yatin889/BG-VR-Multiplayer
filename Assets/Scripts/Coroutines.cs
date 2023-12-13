using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coroutines : MonoBehaviour
{
    public float time;

    public UnityEvent coroutine;


    /////for called in starting 
   void OnEnable()
    {
        StartCoroutine(setActiveFalse());  
    }

    IEnumerator setActiveFalse()
    {
        yield return new WaitForSeconds(time);
        coroutine.Invoke();
    }

}
