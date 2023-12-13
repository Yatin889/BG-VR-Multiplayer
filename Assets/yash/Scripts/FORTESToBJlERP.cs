using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FORTESToBJlERP : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Rubber")
        {
            other.transform.position = Vector3.Lerp(other.transform.position, transform.position, Time.deltaTime * 10f);
        }
    }
}
