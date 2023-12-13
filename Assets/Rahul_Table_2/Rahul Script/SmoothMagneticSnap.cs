using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;


public class SmoothMagneticSnap : MonoBehaviour
{


    public string targetTag; // Tag of the GameObject you want to snap to.
    public GameObject snap; // The GameObject you want to snap.
    public float delayTime; // Delay time before snapping in seconds.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            StartCoroutine(SnapWithDelayCoroutine());
        }
    }

    private IEnumerator SnapWithDelayCoroutine()
    {
        // Wait for the specified delay time.
        yield return new WaitForSeconds(delayTime);

        // Perform the snap logic.
        snap.GetComponent<Rigidbody>().isKinematic = true;
        snap.GetComponent<Grabbable>().enabled = false;

        float t = 0;
        Vector3 initialPosition = snap.transform.position;
        Vector3 targetPosition = transform.position;

        while (t < 1)
        {
            snap.transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
            t += Time.deltaTime * 0.3f;
            yield return null;
        }

        snap.GetComponent<Rigidbody>().isKinematic = false;
        snap.GetComponent<Grabbable>().enabled = true;
    }
}



