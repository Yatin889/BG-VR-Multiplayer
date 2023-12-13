using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    public GameObject[] carwheel;
    public WheelAttach wheel2;
    public Transform lastPos;
    
    [Space]
    [Header("For Rubber Wheels")]
    public float CarRubberspeed;
    public float RubberWheelSpeed;
    
    [Space]
    [Header("For Wood Wheels")]
    public float CarWoodspeed;
    public float WoodWheelSpeed;
 
    [Space]
    [Header("For Steel Wheels")]
    public float CarSteelspeed;
    public float SteelWheelSpeed;

    [HideInInspector]
    public bool Rubber, Wood, Steel;

    [HideInInspector]
    public bool isCompleteTrack;

    float Carspeed, WheelSpeed;

    void Update()
    {
        if(transform.position == lastPos.position)
        {
            WheelSpeed = 0;
            isCompleteTrack = true;
            FalseAllBools();
            GetComponent<CarMove>().enabled = false;
            return;
        }

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

        transform.position = Vector3.MoveTowards(transform.position, lastPos.position, Carspeed * Time.deltaTime);
      
        foreach (GameObject w in wheel2.Wheels)
        {
            w.transform.Rotate(WheelSpeed,0,0);
        }
    }
    public void FalseAllBools()
    {
        if(wheel2.Wheels[1].transform.childCount == 0 && wheel2.Wheels[2].transform.childCount == 0)
        {
            Rubber = false;
            Steel = false;
            Wood = false;

            GetComponent<CarMove>().enabled = false;
        }  
    }
}
