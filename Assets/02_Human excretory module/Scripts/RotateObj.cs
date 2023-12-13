using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObj : MonoBehaviour
{
    public GameObject obj;
    public GameObject UI;
    public bool IsRotate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(IsRotate)
        {
            if (obj.transform.localEulerAngles.y <= 359)
            {
                obj.transform.Rotate(0, 0, 50 * Time.deltaTime);
            }
            else
            {
                obj.transform.Rotate(0, 0, 0);
            }

            if (obj.transform.localEulerAngles.y > 358)
            {
                UI.SetActive(true);
            }
        }  
    }
    public void RotationOn()
    {
        IsRotate = true;
    }
    public void FixRotate()
    {
        IsRotate = false;
        obj.transform.localEulerAngles = new Vector3(-90, 0, 0);
        UI.SetActive(false);
    }
}
