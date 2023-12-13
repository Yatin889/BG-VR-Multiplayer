//////////************* script for enabling & disabling whole steps. ********////////// 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StepManager : MonoBehaviour
{
    [SerializeField]
    [Header("Friction Module")]

    [Header("Table-1-On")]
    public UnityEvent OnTable1;

    [Header("Table-1-Off")]
    public UnityEvent OffTable1;

    [Header("Table-3-On")]
    public UnityEvent OnTable3;

    [Header("Table-3-Off")]
    public UnityEvent OffTable3;



    ///////*******public method which is easy to call when we want invoke events. *********/////////

    #region Table1

    public void onTable1Event()
    {
        OnTable1.Invoke();
    }
 
    public void offTable1Event()
    {
        OffTable1.Invoke();
    }


    #endregion


    #region Table2

    #endregion


    #region Table3

    public void onTable3Event()
    {
        OnTable3.Invoke();
    }

    public void offTable3Event()
    {
        OffTable3.Invoke();
    }


    #endregion
}
