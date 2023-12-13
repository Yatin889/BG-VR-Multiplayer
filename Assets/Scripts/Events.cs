using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Events : MonoBehaviour
{
    public UnityEvent Event;
    
    void Start()
    {
        Event.Invoke();
    }

    public void Call()
    {
        Event.Invoke();
    }

}
