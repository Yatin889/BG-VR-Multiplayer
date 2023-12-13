using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checktier : MonoBehaviour
{
    public GameObject[] car1wheels;
    public GameObject[] car2wheels;
    public GameObject RubberWood;
    public GameObject RubberSteel;
    public GameObject WoodRubber;
    public GameObject WoodSteel;
    public GameObject SteelRubber;
    public GameObject SteelWood;

    public CarForcenew[] CF;
    // Start is called before the first frame update
    private void Update()
    {
        if (CF[0].isComplete || CF[1].isComplete)
        {
            OnCanvas();
        }
    }
    void OnCanvas()
    {
        foreach(GameObject obj in car1wheels)
        {
            foreach(GameObject obj2 in car2wheels)
            {
                if(obj.tag=="Rubber" && obj2.tag=="Wood")
                {
                    RubberWood.SetActive(true);
                }
                else if(obj.tag == "Rubber" && obj2.tag == "Steel")
                {
                    RubberSteel.SetActive(true);
                }
                else if (obj.tag == "Wood" && obj2.tag == "Rubber")
                {
                    WoodRubber.SetActive(true);
                }
                else if (obj.tag == "Wood" && obj2.tag == "Steel")
                {
                    WoodSteel.SetActive(true);
                }
                else if (obj.tag == "Steel" && obj2.tag == "Rubber")
                {
                    SteelRubber.SetActive(true);
                }
                else if (obj.tag == "Steel" && obj2.tag == "Wood")
                {
                    SteelWood.SetActive(true);
                }
            }
        }
    }

    public void DisableAll()
    {
        SteelWood.SetActive(false);
        SteelRubber.SetActive(false);
        WoodSteel.SetActive(false);
        WoodRubber.SetActive(false);
        RubberSteel.SetActive(false);
        RubberWood.SetActive(false);

       // gameObject.SetActive(false);
    }
}
