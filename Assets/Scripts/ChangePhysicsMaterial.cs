using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePhysicsMaterial : MonoBehaviour
{
    public GameObject obj;

    public PhysicMaterial MaterialOnEarth;
    public PhysicMaterial MaterialOnMoon;

    public void PhysicsValueOnEarth()
    {
        obj.GetComponent<Collider>().material = MaterialOnEarth;
    }

    public void PhysicsValueOnMoon()
    {
        obj.GetComponent<Collider>().material = MaterialOnMoon;

    }
}
