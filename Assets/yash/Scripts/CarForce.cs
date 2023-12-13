using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarForce : MonoBehaviour
{
    public GameObject car;
    public GameObject[] carwheel;
    public GameObject lastPos;
    public float CarRubberspeed, RubberWheelSpeed, CarWoodspeed, WoodWheelSpeed, CarSteelspeed, SteelWheelSpeed;
    public bool Rubber,Wood,Steel;
    /*public ParticleSystem smoke;*/
    Vector3 startPos; 
    void Start()
    {
        /*startPos = car.transform.position;*/
    }

    void Update()
    {
        if (Rubber)
        {
            car.transform.position = Vector3.MoveTowards(transform.position, lastPos.transform.position, CarRubberspeed * Time.deltaTime);
            foreach (GameObject obj in carwheel)
            {
                obj.transform.Rotate(RubberWheelSpeed,0, 0);
                /*smoke.gameObject.SetActive(true);*/
                if(car.transform.position==lastPos.transform.position)
                {
                    obj.transform.Rotate(0,0,0);
                }
            }
        }
        if (Wood)
        {
            car.transform.position = Vector3.MoveTowards(transform.position, lastPos.transform.position, CarWoodspeed * Time.deltaTime);
            foreach (GameObject obj in carwheel)
            {
                obj.transform.Rotate(WoodWheelSpeed, 0, 0);
                /*smoke.gameObject.SetActive(true);*/
                if (car.transform.position == lastPos.transform.position)
                {
                    obj.transform.Rotate(0, 0, 0);
                }
            }
        }
        if (Steel)
        {
            car.transform.position = Vector3.MoveTowards(transform.position, lastPos.transform.position, CarSteelspeed * Time.deltaTime);
            foreach (GameObject obj in carwheel)
            {
                obj.transform.Rotate(SteelWheelSpeed,0, 0);
                /*smoke.gameObject.SetActive(true);*/
                if (car.transform.position == lastPos.transform.position)
                {
                    obj.transform.Rotate(0, 0, 0);
                }
            }
        }
        
    }
}
