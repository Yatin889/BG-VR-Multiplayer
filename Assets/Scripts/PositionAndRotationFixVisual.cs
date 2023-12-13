using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionAndRotationFixVisual : MonoBehaviour
{
    /*public GameObject obj;*/
    void OnEnable()
    {

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(-90, 0, -90);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Table")
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Table")
        {
            GetComponent<Rigidbody>().freezeRotation = false;
        }
    }
}
