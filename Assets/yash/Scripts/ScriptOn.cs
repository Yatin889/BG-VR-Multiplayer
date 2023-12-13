using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ScriptOn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject button;
    /*public AudioSource ToycarAudio;*/
    /*public CarForce[] carForce;*/
    public ObjectLerp[] Car1;
    public ObjectLerp[] Car2;
    public CarForcenew[] carForcenew;
    public GameObject Highlight;

    bool isMove;
    public void caron()
    {
        StartCoroutine(cardelay());
    }
    void OnEnable()
    {
        GetComponent<Collider>().enabled = false;
    }
    private void Update()
    {
        foreach (ObjectLerp ol1 in Car1)
        {
            foreach (ObjectLerp ol2 in Car2)
            {
                if (ol1.isTure && ol2.isTure)
                {
                    Highlight.SetActive(true);
                    GetComponent<Collider>().enabled = true;
                    isMove = true;
                }
            }
        }
    }
    public void caronnew()
    {
        if (isMove == true)
        {
            StartCoroutine(cardelay());
        }
    }
    IEnumerator cardelay()
    {   
        yield return new WaitForSeconds(3);

        isMove = false;

        foreach (CarForcenew CF in carForcenew)
        {
            CF.enabled = true;
        }

        foreach (ObjectLerp ol1 in Car1)
        {
            foreach (ObjectLerp ol2 in Car2)
            {
                ol1.isTure = false;
                ol2.isTure = false;
            }
        }
    }
   
}
