using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelPosChange : MonoBehaviour
{
    public Transform Wheel2, Wheel3;
    public void ChangePosition(float number)
    {
        if (number == 2)
        {
            if (Wheel3.childCount > 0)
            {
               // Wheel3.GetChild(1).transform.parent = Wheel2.transform.parent;
                Wheel3.GetChild(1).transform.position = Wheel2.transform.position;
            }
        }
        else if(number == 3)
        {
            if(Wheel2.childCount > 1)
            {
               // Wheel2.GetChild(1).transform.parent = Wheel3.transform.parent;
                Wheel2.GetChild(1).transform.position = Wheel3.transform.position;
            }      
        }
    }
}
