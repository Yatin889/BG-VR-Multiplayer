using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class DisaableAfterDelay : MonoBehaviour
{
    public float Duration;

    [Space]
    [Header("After this gameobject eneable, this event will be performed")]
    public UnityEvent EnableEvent;

    [Space]
    [Header("After Delay this event will be performed")]
    public UnityEvent DelayEvent;

    [Header("Disable This GameObject After Delay")]
    public bool isDisable;

    void OnEnable()
    {
        EnableEvent.Invoke();
        StartCoroutine(WaitForEnable());
    }

    IEnumerator WaitForEnable()
    {
        yield return new WaitForSeconds(Duration);
        DelayEvent.Invoke();

        if(isDisable)
        {
            this.gameObject.SetActive(false);
        }
    }
}
    