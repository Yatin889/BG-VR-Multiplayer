using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class afterDelayEvents : MonoBehaviour
{
    public float Duration;
    public UnityEvent DelayTime;


    /*public void OnEnable()
    {
        StartCoroutine(TimeDelay());
    }*/


/*    IEnumerator TimeDelay()
    {
        yield return new WaitForSeconds(Duration);
        DelayTime.Invoke();
    }*/
    IEnumerator PlayAudioDelayed()
    {
        yield return new WaitForSeconds(Duration);
        GetComponent<AudioSource>().Play();
    }

    void Start()
    {
        StartCoroutine(PlayAudioDelayed());
    }

}
