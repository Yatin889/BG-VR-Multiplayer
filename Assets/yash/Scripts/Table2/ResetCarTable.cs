using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCarTable : MonoBehaviour
{
    public Transform GrabWheelParent;

    [Space]
    [Header("Car 1 & Car 2 Position Reset")]
    public CarMove[] Car;

    [Space]
    [Header("Reset TriggerWheel Material")]
    public WheelAttach[] CarWheel;

    [Space]
    [Header("Reset Wheels Position & Rotation")]
    public GameObject[] GrabWheel;

    [HideInInspector] public List<Vector3> DefaultWheelPos;
    [HideInInspector] public List<Quaternion> DefaultWheelRotation;

    [HideInInspector] public List<Vector3> DefaultCarPos;
    [HideInInspector] public List<Quaternion> DefaultCarRotation;

    void Start()
    {
        for (int i = 0; i < GrabWheel.Length; i++)
        {
            DefaultWheelPos.Add(GrabWheel[i].transform.position);
            DefaultWheelRotation.Add(GrabWheel[i].transform.rotation);
        }

        for (int j = 0; j < Car.Length; j++)
        {
            DefaultCarPos.Add(Car[j].transform.position);
            DefaultCarRotation.Add(Car[j].transform.rotation);
        }
    }

    public void ResetTransform()
    {
        for (int i = 0; i < GrabWheel.Length; i++)
        {
            GrabWheel[i].transform.position = DefaultWheelPos[i];
            GrabWheel[i].transform.rotation = DefaultWheelRotation[i];
            GrabWheel[i].SetActive(true);

            GrabWheel[i].transform.parent = GrabWheelParent;

            GrabWheel[i].GetComponent<Collider>().enabled = true;
            GrabWheel[i].GetComponent<Rigidbody>().isKinematic = true;
        }

        for (int j = 0; j < Car.Length; j++)
        {
            Car[j].enabled = false;
            Car[j].transform.position = DefaultCarPos[j];
            Car[j].transform.rotation = DefaultCarRotation[j];
        }

        foreach(WheelAttach WA in CarWheel)
        {
            WA.GetComponent<WheelAttach>().EndProcess();
        }
    }
}
