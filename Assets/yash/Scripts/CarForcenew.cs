using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarForcenew : MonoBehaviour
{
    public GameObject car;
    public GameObject[] carwheel;
    public GameObject lastPos;

    public float CarRubberspeed;
    public float RubberWheelSpeed;
    [Space]
    public float CarWoodspeed;
    public float WoodWheelSpeed;
    [Space]
    public float CarSteelspeed;
    public float SteelWheelSpeed;

    [HideInInspector]
    public bool Rubber, Wood, Steel;

    [HideInInspector]
    public bool isComplete;
    
    float Carspeed, WheelSpeed;

    void Update()
    {
        if (Rubber)
        {
            Carspeed = CarRubberspeed;
            WheelSpeed = RubberWheelSpeed;    
        }
        else if (Wood)
        {
            Carspeed = CarWoodspeed;
            WheelSpeed = WoodWheelSpeed;
        }
        else if (Steel)
        {
            Carspeed = CarSteelspeed;
            WheelSpeed = SteelWheelSpeed;
        }

        car.transform.position = Vector3.MoveTowards(transform.position, lastPos.transform.position, Carspeed * Time.deltaTime);
        foreach (GameObject obj in carwheel)
        {
            if (car.transform.position == lastPos.transform.position)
            {
                WheelSpeed = 0;
                isComplete = true;
                FalseAllBools();
            }
            else
            {
                obj.transform.Rotate(WheelSpeed, 0, 0);
            }
        }
    }
    public void FalseAllBools()
    {
        Rubber = false;
        Steel = false;
        Wood = false;

        GetComponent<CarForcenew>().enabled = false;
    }
}
      
