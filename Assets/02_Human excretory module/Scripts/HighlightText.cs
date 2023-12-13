using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightText : MonoBehaviour
{
    public GameObject obj;
    public Material Mat;
    Color emissiveColor;
    // Start is called before the first frame update
    void Start()
    {
        //Color emissiveColor = obj.GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MaterialHighlight()
    {
      //  obj.GetComponent<Material>().EnableKeyword("_EMISSION");
        Mat.EnableKeyword("_EMISSION");
    }
    public void OnDisable()
    {
        //  obj.GetComponent<Material>().EnableKeyword("_EMISSION");
        Mat.DisableKeyword("_EMISSION");
    }
 /*   public void Disablematerial()
    {
        //  obj.GetComponent<Material>().EnableKeyword("_EMISSION");
        Mat.DisableKeyword("_EMISSION");
    }*/
}
