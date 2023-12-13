using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BlinkLoader : MonoBehaviour
{
    public Blinker blinker;
    [Tooltip("Load or execute the script whenever the gameobject is set to active")]
    public bool loadOnEnable = false;

    public float closeDuration = 1f;
    public float stayDuration = 0.25f;
    public float openDuration = 1f;

    [Tooltip("Performed when the screen is entirely black")]
    public UnityEvent onLoad;
    public UnityEvent onComplete;

	private void OnEnable()
	{
        if (loadOnEnable)
        {
            blinkLoad();
        }
	}

	public void blinkLoad()
    {
        StartCoroutine(_blinkLoad());
    }

    IEnumerator _blinkLoad()
    {
		blinker.blinkThreePhase(closeDuration, stayDuration, openDuration);

        yield return new WaitForSeconds(closeDuration);
        onLoad.Invoke();

        yield return new WaitForSeconds(stayDuration + openDuration);
        onComplete.Invoke();

	}
}
