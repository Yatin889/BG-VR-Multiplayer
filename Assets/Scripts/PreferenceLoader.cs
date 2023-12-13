using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreferenceLoader : MonoBehaviour
{

    public GameObject[] objToBeDisabled;
    public GameObject[] objToBeEnabled;


    private void OnEnable()
    {
        if (PlayerPrefs.HasKey("GameStart"))
        {
            for (int i = 0; i < objToBeDisabled.Length; i++)
            {
                Debug.Log(objToBeDisabled[i]);

                objToBeDisabled[i].SetActive(false);
            }

            for (int i = 0; i < objToBeEnabled.Length; i++)
            {
                Debug.Log(objToBeEnabled[i]);

                objToBeEnabled[i].SetActive(true);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }

    static void Quit()
    {
        PlayerPrefs.DeleteAll();
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus == true)
        {
            Debug.Log("OnApplicationFocus" + hasFocus);
        }
        else
        {
           // PlayerPrefs.SetInt("Environment", 0);
            PlayerPrefs.DeleteAll();
            Debug.Log("OnApplicationFocus" + hasFocus);
        }
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus == true)
        {
           // PlayerPrefs.SetInt("Environment", 0);
            PlayerPrefs.DeleteAll();
            Debug.Log("OnApplicationPause" + pauseStatus);
        }
        else
        {
            Debug.Log("onapplicationpause" + pauseStatus);
        }
    }

}
