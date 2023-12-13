using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelsSpone: MonoBehaviour
{
    public GameObject RubberWheels,SteelWheels, WoodWheels, SimpleWheels;
    public CarForce carForce;
   
    

    void Start()
    {
        
    }
    void Update()
    {
     
    }

    void OnTriggerEnter(Collider other)
    {
        
            if (other.tag == "Rubber")
            {
                RubberWheels.SetActive(true);
                SimpleWheels.SetActive(false);
                SteelWheels.SetActive(false);
                WoodWheels.SetActive(false);
                carForce.Wood = false;
                carForce.Steel = false;
                carForce.Rubber = true;

            }
        
      
            if (other.tag == "Steel")
            {
                SteelWheels.SetActive(true);
                SimpleWheels.SetActive(false);
                RubberWheels.SetActive(false);
                WoodWheels.SetActive(false);
                carForce.Wood = false;
                carForce.Rubber = false;
                carForce.Steel = true;
            }
   
            if (other.tag == "Wood")
            {
                WoodWheels.SetActive(true);
                SimpleWheels.SetActive(false);
                SteelWheels.SetActive(false);
                RubberWheels.SetActive(false);
                carForce.Steel = false;
                carForce.Rubber = false;
                carForce.Wood = true;
            }
        
        
        
    }
       
}
