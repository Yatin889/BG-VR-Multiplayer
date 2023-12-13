using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSnapObj : MonoBehaviour
{
 
 
    public float snapDistance = 1f; // The distance at which objects will snap to each other.
    public float snapSpeed = 10f; // The speed at which objects will snap to each other.
    public bool snapAgainWhenGrabbed = true; // Whether or not objects will snap to each other again when grabbed after being released.
    public float distance;
    private Rigidbody rb;
    private Transform targetTransform;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Find the closest object to snap to.
        targetTransform = null;
        float closestDistance = snapDistance;
        foreach (Collider collider in Physics.OverlapSphere(transform.position, snapDistance))
        {
            if (collider.gameObject != gameObject)
            {
                float distance = Vector3.Distance(transform.position, collider.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    targetTransform = collider.transform;
                }
            }
        }

        // If there is a target object, snap to it.
        if (targetTransform != null)
        {
            // Calculate the direction to the target object.
            Vector3 direction = targetTransform.position - transform.position;

            // Move towards the target object at a constant speed.
            rb.AddForce(direction.normalized * snapSpeed);

            // If the object is close enough to the target object, snap to it.
            if (distance < snapDistance * 0.5f)
            {
                transform.position = targetTransform.position;
                rb.velocity = Vector3.zero;
            }
        }

        // If the object is grabbed, snap it to the target object again if necessary.
        if (snapAgainWhenGrabbed && Input.GetKey(KeyCode.Mouse0))
        {
            if (targetTransform != null)
            {
                transform.position = targetTransform.position;
            }
        }
    }

   public void OnTriggerEnter(Collider collider)
    {
        // If the object enters a trigger collider, snap to the target object.
        if (targetTransform != null)
        {
            transform.position = targetTransform.position;
        }
    }
}


