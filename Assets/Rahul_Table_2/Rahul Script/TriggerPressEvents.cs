using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class TriggerPressEvents : MonoBehaviour
{
    public UnityEvent onPressEvents;
    public string Tag;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tag)
        {
            onPressEvents.Invoke();
        }
    }
}
