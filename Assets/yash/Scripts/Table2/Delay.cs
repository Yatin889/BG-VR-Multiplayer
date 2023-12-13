using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Delay : MonoBehaviour
{
    public float Duration;
   
    [Space]
    public UnityEvent AfterDelayEvent;

    [Space][Header("After Delay disable this gameObject")]
    public bool Disable;

    private void OnEnable()
    {
        StartCoroutine(WaitForDelay());
    }

    IEnumerator WaitForDelay()
    {
        yield return new WaitForSeconds(Duration);
       
        AfterDelayEvent.Invoke();

        if(Disable)
        {
            gameObject.SetActive(false);
        }
    }
}
