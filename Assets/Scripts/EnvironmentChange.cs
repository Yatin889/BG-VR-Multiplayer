using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentChange : MonoBehaviour
{
    public Renderer Environment;
    public Material Earth, Moon;
    public GameObject UIEarth, UIMoon;

    private void OnEnable()
    {
        if(PlayerPrefs.GetInt("Environment") == 0)
        {
            Environment.material = Earth;
            UIEarth.SetActive(true);
            UIMoon.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Environment") == 1)
        {
            Environment.material = Moon;
            UIMoon.SetActive(true);
            UIEarth.SetActive(false);
        }
    }
}
