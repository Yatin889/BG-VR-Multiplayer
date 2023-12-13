using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotaion : MonoBehaviour
{
    public float time;
    private void OnEnable()
    {
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(time);
        transform.localEulerAngles = Vector3.zero;
    }
}
