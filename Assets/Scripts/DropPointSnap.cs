using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropPointSnap : MonoBehaviour
{     
    public bool isSnap = false;
    public bool isOffObject = false;
    public float learpSpeed = 1f;
    public float time;
    public GameObject InstructionPanel; 
    public GameObject GhostAnim;
    public GameObject DropPoint;
    public float freezeTime = 3f;
    private bool isFrozen = false;

    private void OnTriggerEnter(Collider collision)
     {
        if(collision.gameObject == DropPoint && !isSnap)
        {
            StartCoroutine(LerpTowardDropPoint());
            isSnap = true;
            StartCoroutine(Destroy());
            InstructionPanel.gameObject.SetActive(true);
            StartCoroutine(FreezeObj());
        }
     }
    IEnumerator LerpTowardDropPoint()
    {
        float t = 0f;
        Vector3 startPos = transform.position;
        Vector3 endPos = DropPoint.transform.position;

        while(t < 1f)
        {
            t += Time.deltaTime * learpSpeed;
            transform.position = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }
    }
    IEnumerator Destroy()
    {
        if (isOffObject)
        {
            yield return new WaitForSeconds(time);
            Destroy(DropPoint);
            Destroy(GhostAnim);
        }    
    }

    IEnumerator FreezeObj()
    {
        isFrozen = true;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        yield return new WaitForSeconds(freezeTime);
        rb.isKinematic = false;
        isFrozen = false;
    }
}
