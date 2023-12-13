using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioSoundDelay : MonoBehaviour
{

    public float time;  
    public float time2;
    public UnityEvent coroutine; 
    public UnityEvent coroutine2;
    void Start()
    {
        StartCoroutine(setActiveFalse());
    }
    IEnumerator setActiveFalse()
    {
        yield return new WaitForSeconds(time);
        coroutine.Invoke();
        yield return new WaitForSeconds(time2);
        coroutine2.Invoke();
    }
}
