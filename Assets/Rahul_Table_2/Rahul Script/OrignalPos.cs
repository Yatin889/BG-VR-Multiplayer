using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrignalPos : MonoBehaviour
{
    public GameObject woodpos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        woodpos.transform.position = transform.position;
        woodpos.transform.rotation = transform.rotation;
        woodpos.transform.localScale = transform.localScale;
    }
}
