using System.Collections;
using TMPro;
using UnityEngine;

public class CountDown : MonoBehaviour
{

    public TextMeshProUGUI countdownText;
    public float delayBeforeCountdown = 3.0f;
    public float countdownDuration = 3.0f;
    private float startTime;
    public AudioSource countdownAudio; // Assign the audio source in the Inspector

    private void Start()
    {
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(delayBeforeCountdown);

        startTime = Time.time;

        while (Time.time - startTime < countdownDuration)
        {
            int countdownValue = Mathf.CeilToInt(countdownDuration - (Time.time - startTime));
            countdownText.text = countdownValue.ToString();

            // Play the audio for the countdown
            countdownAudio.Play();

            yield return new WaitForSeconds(1.0f); // Delay between each count
        }

        countdownText.text = "Go!";
        countdownAudio.Play(); // Play the audio for "Go!"

        // Wait for a brief delay before hiding the object
        yield return new WaitForSeconds(1.0f);

        countdownText.gameObject.SetActive(false); // Disable the TextMeshPro object
        countdownAudio.Stop();
        // Add any code here that you want to run after the countdown is complete.
    }
}




