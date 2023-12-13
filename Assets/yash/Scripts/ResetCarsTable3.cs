using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCarsTable3 : MonoBehaviour
{

    public CarForcenew[] CF;
    public GameObject highlight;

    [Space]
    [Header("Car 1 & Car 2 Position Reset")]
    public GameObject[] Car;

    [Space]
    [Header("Reset TriggerWheel Material")]
    public GameObject[] TriggerWheel;

    [Space]
    [Header("Reset Wheels Position & Rotation")]
    public GameObject[] Wheels;

    [HideInInspector]public List<Vector3> DefaultWheelPos;
    [HideInInspector]public List<Quaternion> DefaultWheelRotation;

    [HideInInspector]public List<Vector3> DefaultCarPos;
    [HideInInspector]public List<Quaternion> DefaultCarRotation;

    [HideInInspector]
    public Material DefaultMat;

    void Start()
    {
        DefaultMat = TriggerWheel[0].GetComponent<Renderer>().material;

        for(int i = 0; i < Wheels.Length; i++)
        {
            DefaultWheelPos.Add(Wheels[i].transform.position);
            DefaultWheelRotation.Add(Wheels[i].transform.rotation);
        }

        for(int j = 0; j < Car.Length; j++)
        {
            DefaultCarPos.Add(Car[j].transform.position);
            DefaultCarRotation.Add(Car[j].transform.rotation);
        }
    }

    private void Update()
    {
        if(CF[0].isComplete && CF[1].isComplete)
        {
            highlight.SetActive(true);
            GetComponent<Collider>().enabled = true;
            CF[0].isComplete = false;
            CF[1].isComplete = false;
        }
    }
    public void ResetTransform()
    {
        for (int i = 0; i < Wheels.Length; i++)
        {
            Wheels[i].transform.position = DefaultWheelPos[i];
            Wheels[i].transform.rotation = DefaultWheelRotation[i];

            Wheels[i].GetComponent<Collider>().enabled = true;
            Wheels[i].GetComponent<Rigidbody>().isKinematic = true;
        }

        for (int j = 0; j < Car.Length; j++)
        {
            Car[j].GetComponent<CarForcenew>().enabled = false;

            Car[j].transform.position = DefaultCarPos[j];
            Car[j].transform.rotation = DefaultCarRotation[j];
        }

        for(int k = 0; k < TriggerWheel.Length; k++)
        {
            TriggerWheel[k].GetComponent<Renderer>().material = DefaultMat;
            TriggerWheel[k].tag = null;
        }
    }
    public void OffWheelCollider()
    {
        for (int i = 0; i < Wheels.Length; i++)
        {
            Wheels[i].GetComponent<Collider>().enabled = false;
            Wheels[i].GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
