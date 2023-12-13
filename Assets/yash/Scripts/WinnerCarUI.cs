using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerCarUI : MonoBehaviour
{
    public GameObject rubberUI, steelUI, woodUI;
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
        if(other.tag=="Rubber")
        {
            GetComponent<Collider>().enabled = false;
            rubberUI.SetActive(true);
        }
        if (other.tag == "Steel")
        {
            GetComponent<Collider>().enabled = false;
            steelUI.SetActive(true);
        }
        if (other.tag == "Wood")
        {
            GetComponent<Collider>().enabled = false;
            woodUI.SetActive(true);
        }
    }
}
