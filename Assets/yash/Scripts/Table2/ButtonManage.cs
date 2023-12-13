using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ButtonManage : MonoBehaviour
{
    public GameObject _StartButton;
    public GameObject _ResetButton;

    [Space]
    public WheelAttach[] Car1;
    public WheelAttach[] Car2;

    [Space]
    public CarMove[] carMove;

    [Space]
    public UnityEvent SatrtButtonEvent;
    public UnityEvent SatrtButtonExit;
    public UnityEvent ResetButtonEvent;
   

    int StartCount, ResetCount;
    private void Update()
    {
        if (!Car1[0].isComplete)
        {
            _StartButton.GetComponent<Collider>().enabled = false;
            StartCount = 0;
        }

        foreach(WheelAttach w1 in Car1)
        {
            foreach(WheelAttach w2 in Car2)
            {
                if(w1.isComplete && w2.isComplete)
                {
                    if(StartCount == 0)
                    {
                        _StartButton.GetComponent<Collider>().enabled = true;
                    }

                    SatrtButtonEvent.Invoke();
                    StartCount++;
                }
                else
                {
                    SatrtButtonExit.Invoke();
                }
            }
        }

        if (carMove[0].isCompleteTrack && carMove[1].isCompleteTrack && ResetCount == 0)
        {
            _ResetButton.GetComponent<Collider>().enabled = true;
            ResetButtonEvent.Invoke();
            ResetCount++;
        }

    }

    public void CountZero()
    {
        carMove[0].isCompleteTrack = false;
        carMove[1].isCompleteTrack = false;
        StartCount = 0;
        ResetCount = 0;
    }
}
