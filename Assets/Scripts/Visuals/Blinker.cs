using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinker : MonoBehaviour
{
    public RectTransform canvas;
    public RectTransform upperBlind;
    public RectTransform lowerBlind;

    float midWidth;

	public Camera mainCamera;

	private void Start()
	{
		midWidth = canvas.sizeDelta.y / 2;
		canvas.transform.GetComponent<Canvas>().worldCamera = mainCamera;
	}

	public void blink(float duration = 2f)
	{
		StartCoroutine(_blink(duration));
	}

	public void blinkThreePhase(float closeDuration, float stayDuration, float openDuration)
	{
		StartCoroutine(_blinkThreePhase(closeDuration, stayDuration, openDuration));
	}

	IEnumerator _blink(float duration)
	{
		float time = 0;
		while(time < duration / 2)
		{
			upperBlind.sizeDelta = new Vector2(upperBlind.sizeDelta.x, midWidth * (2 * time / duration));
			lowerBlind.sizeDelta = new Vector2(lowerBlind.sizeDelta.x, midWidth * (2 * time / duration));
			time += Time.deltaTime;
			yield return null;
		}

		while (time >= 0) 
		{
			upperBlind.sizeDelta = new Vector2(upperBlind.sizeDelta.x, midWidth * (2 * time / duration));
			lowerBlind.sizeDelta = new Vector2(lowerBlind.sizeDelta.x, midWidth * (2 * time / duration));
			time -= Time.deltaTime;
			yield return null;
		}
	}

	IEnumerator _blinkThreePhase(float closeDuration, float stayDuration, float openDuration)
	{
		float time = 0;
		while (time <= closeDuration + 0.1f)
		{
			upperBlind.sizeDelta = new Vector2(upperBlind.sizeDelta.x, midWidth * (time / closeDuration));
			lowerBlind.sizeDelta = new Vector2(lowerBlind.sizeDelta.x, midWidth * (time / closeDuration));
			time += Time.deltaTime;
			yield return null;
		}

		yield return new WaitForSeconds(stayDuration);

		while (time + 0.1f >= 0)
		{
			upperBlind.sizeDelta = new Vector2(upperBlind.sizeDelta.x, midWidth * (time / openDuration));
			lowerBlind.sizeDelta = new Vector2(lowerBlind.sizeDelta.x, midWidth * (time / openDuration));
			time -= Time.deltaTime;
			yield return null;
		}
	}
}
