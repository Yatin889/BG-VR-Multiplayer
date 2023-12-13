using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public GameObject car1,car2;
    public GameObject Wrubber,Wsteel,Wwood;
   
    Vector3 defaultposc1;
    Vector3 defaultposc2;
    Vector3 defaultposWR;
    Vector3 defaultposWS;
    Vector3 defaultposWW;
    Vector3 defaultrotationWR;
    Vector3 defaultrotationWS;
    Vector3 defaultrotationWW;
    // Start is called before the first frame update
    void Start()
    {
        defaultposc1 = car1.transform.position;
        defaultposc2 = car2.transform.position;

        defaultposWR = Wrubber.transform.position;
        defaultposWS = Wsteel.transform.position;
        defaultposWW = Wwood.transform.position;

        defaultrotationWR = Wrubber.transform.eulerAngles;
        defaultrotationWS = Wsteel.transform.eulerAngles;
        defaultrotationWW = Wwood.transform.eulerAngles;


        
    }

    void Update()
    {
        
    }
    public void resetCar()
    {
        car1.transform.position = defaultposc1;
        car2.transform.position = defaultposc2;

        Wrubber.transform.position = defaultposWR;
        Wsteel.transform.position = defaultposWS;
        Wwood.transform.position = defaultposWW;

        Wrubber.transform.eulerAngles = defaultrotationWR;
        Wsteel.transform.eulerAngles = defaultrotationWS;
        Wwood.transform.eulerAngles = defaultrotationWW;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "hand")
        {
            resetCar();
        }
    }
}
