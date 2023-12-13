using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPose : MonoBehaviour
{
    public GameObject obj;
    public GameObject targetCollider;
    public GameObject empty;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == targetCollider.gameObject)
        {
            obj.transform.position = empty.transform.position;
            obj.transform.rotation = empty.transform.rotation;
            obj.GetComponent<Rigidbody>().isKinematic = true;
          //  StartCoroutine(rigidbodyConstraint());
           // StartCoroutine(ReleafeRigidbodyConstraint());
        }
    }
    public void resetpos()
    {
        obj.transform.position = empty.transform.position;
        obj.transform.rotation = empty.transform.rotation;
        obj.GetComponent<Rigidbody>().isKinematic = true;
    }
  /*  IEnumerator rigidbodyConstraint()
    {
        yield return new WaitForSeconds(2f);
        obj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    IEnumerator ReleafeRigidbodyConstraint()
    {
        Debug.Log("2");
        yield return new WaitForSeconds(1f);
        obj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }
  */
}

