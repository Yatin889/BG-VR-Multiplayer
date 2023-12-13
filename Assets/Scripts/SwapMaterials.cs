using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapMaterials : MonoBehaviour
{
    public GameObject earth;
    public GameObject moon;

    public bool IsTrue = false;

    public Material earthM;
    public Material moonM;

    public ChangePhysicsMaterial steal;
    public ChangePhysicsMaterial wood;
    public ChangePhysicsMaterial rubber;


    public void ChangeMaterial(Material newMaterial)
    {
        if (IsTrue == false)
        {
            GetComponent<Renderer>().material = newMaterial;
            moon.GetComponent<Renderer>().material = earthM;
            IsTrue = true;

            steal.PhysicsValueOnMoon();
            wood.PhysicsValueOnMoon();
            rubber.PhysicsValueOnMoon();
        }

        else if (IsTrue)
        {
            moon.GetComponent<Renderer>().material = moonM;
            earth.GetComponent<Renderer>().material = earthM;
            IsTrue = false;

            steal.PhysicsValueOnEarth();
            wood.PhysicsValueOnEarth();
            rubber.PhysicsValueOnEarth();
        }
    }
}
