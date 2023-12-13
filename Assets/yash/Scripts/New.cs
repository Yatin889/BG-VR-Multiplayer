using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class New : MonoBehaviour
{
    public GameObject[] wheels;
    public Material[] material;
    Renderer rend, rend1;
    public CarForcenew CarForcenew;

    public UnityEvent AfterLerp;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    // Update is called once per frame
    public void firstmaterial()
    {
        rend1.sharedMaterial = material[0];
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Rubber")
        {
            wheelmaterialchange(1);
            CarForcenew.Rubber = true;
            CarForcenew.Wood = false;
            CarForcenew.Steel = false;
            AfterLerp.Invoke();
        }
        if (other.gameObject.tag =="Steel")
        {
            wheelmaterialchange(2);
            CarForcenew.Steel = true;
            CarForcenew.Rubber = false;
            CarForcenew.Wood = false;
            AfterLerp.Invoke();
        }
        if (other.gameObject.tag =="Wood")
        {
            wheelmaterialchange(3);
            CarForcenew.Wood = true;
            CarForcenew.Steel = false;
            CarForcenew.Rubber = false;
            AfterLerp.Invoke();
        }
    }

    public void wheelmaterialchange(int i)
    {
        foreach (GameObject wh in wheels)
        {
            wh.GetComponent<Renderer>().material = material[i];
        }
    }
}
