using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
public class CountdownStart : MonoBehaviour
{
    [Header("When you call the StartCountDown method, \nEnter the value from where the countdown will be start.")]
    [Space(20)]
    public TextMeshProUGUI CountDownText;
    [Space]
    public string EndInstruction;
    public AudioSource InstructionAudio;
    [Space]
    public bool isResetText;
    public float ResetTime;
    [Space][Header("After Reset Time this event call")]
    public UnityEvent AfterReset;

    public void StartCountDown(float Time)
    {
        StartCoroutine(StartTimer(Time));
    }
    IEnumerator StartTimer(float time)
    {
        while(time > 0)
        {
            time -= Time.deltaTime;
            CountDownText.enabled = false;
            CountDownText.text = time.ToString("0");

            if(time < 1)
            {
                CountDownText.enabled = true;
                CountDownText.text = EndInstruction;

                InstructionAudio.enabled = true;
                Invoke("ResetText", ResetTime);
            }
            yield return null;
        }
    }

    public void ResetText()
    {
        if(isResetText)
        {
            CountDownText.text = "";
            AfterReset.Invoke();
        } 
    }
}
