using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjHighlightArray : MonoBehaviour
{
    public Outlinee[] obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HighlightOn()
    {
        foreach(Outlinee Ol in obj)
        {
            Ol.enabled = true;
        }
    }
    public void HighlightOff()
    {
        foreach (Outlinee Ol in obj)
        {
            Ol.enabled = false;
        }
    }
}
