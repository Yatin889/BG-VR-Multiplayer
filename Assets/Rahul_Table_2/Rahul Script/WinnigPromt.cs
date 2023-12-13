using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinnigPromt : MonoBehaviour
{
    public Snap_Table2[] ST;

    [Space]
    public GameObject R_and_W_Canvas;
    public GameObject R_and_S_Canvas;
    public GameObject W_and_S_Canvas;
    public BoxCollider levercolider;
    public UnityEvent resetOff;
    private void OnEnable()
    {
        if (ST[0].isWood && ST[1].isSteel || ST[0].isSteel && ST[1].isWood)
        {
            W_and_S_Canvas.SetActive(true);
            levercolider.enabled = true;
            resetOff.Invoke();
          //  W_and_S_Canvas.GetComponent<AudioSource>().Play();
        }
        else if(ST[0].isWood && ST[1].isRubber || ST[0].isRubber && ST[1].isWood)
        {
            R_and_W_Canvas.SetActive(true);
            levercolider.enabled = true;
            resetOff.Invoke();
            //  R_and_W_Canvas.GetComponent<AudioSource>().Play();
        }
        else if(ST[0].isRubber && ST[1].isSteel || ST[0].isSteel && ST[1].isRubber)
        {
            R_and_S_Canvas.SetActive(true);
            levercolider.enabled = true;
            resetOff.Invoke();
            // R_and_S_Canvas.GetComponent<AudioSource>().Play();
        }
    }

    public void DisbalAllCanvas()
    {
        W_and_S_Canvas.SetActive(false);
        R_and_W_Canvas.SetActive(false);
        R_and_S_Canvas.SetActive(false);
  
        GetComponent<WinnigPromt>().enabled = false;
    }
}


