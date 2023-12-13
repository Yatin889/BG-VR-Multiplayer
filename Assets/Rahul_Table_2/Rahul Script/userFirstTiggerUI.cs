using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class userFirstTiggerUI : MonoBehaviour
{

	/*    public UnityEvent[] triggerEnter;
		public float delay;
		// public GameObject[] objectsToActivate;
		private void OnTriggerEnter(Collider other)
		{
			// Check if the entering object has a specific tag or layer to filter which objects to activate.
			if (other.CompareTag("Player") || other.gameObject.layer == LayerMask.NameToLayer("Player"))
			{
				// Loop through the array of game objects and activate them.
				foreach (UnityEvent unityEvent in triggerEnter)
				{
					StartCoroutine(InvokeEventWithDelay(unityEvent));

				}
			}
		}

		//Invoke the specific UnityEvent passed as a parameter.

		private IEnumerator InvokeEventWithDelay(UnityEvent unityEvent)
		{
			yield return new WaitForSeconds(delay);
			unityEvent.Invoke();
			Debug.Log("call");
		}*/
	public bool forSpecificObject = false;
	public Collider targetCollider;
	public UnityEvent triggerEnter;
	public UnityEvent triggerStay;
	public UnityEvent triggerExit;
	private void OnTriggerEnter(Collider other)
	{
		if (forSpecificObject)
		{
			if (other == targetCollider)
			{
				triggerEnter.Invoke();
			}
		}
		else
		{
			triggerEnter.Invoke();
		}
	}
	private void OnTriggerStay(Collider other)
	{
		if (forSpecificObject)
		{
			if (other == targetCollider)
			{
				triggerStay.Invoke();
			}
		}
		else
		{
			triggerStay.Invoke();
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (forSpecificObject)
		{
			if (other == targetCollider)
			{
				triggerExit.Invoke();
			}
		}
		else
		{
			triggerExit.Invoke();
		}
	}
}



