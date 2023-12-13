using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationFix : MonoBehaviour
{

    private GameObject MainCamera;

    void OnEnable()
    {
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.identity;
        //transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
        transform.Rotate(0, 0, 0);

       transform.LookAt(MainCamera.transform);

    }
}
