using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DisableEvents : MonoBehaviour
{
    public UnityEvent onPerform;

    private void OnDisable()
    {
        onPerform.Invoke();
    }
}
