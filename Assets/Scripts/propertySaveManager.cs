using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class propertySaveManager : MonoBehaviour
{
    public GameObject[] objs;

    int count = 0;

    public GameObject[] objToBeDestroyed;
    public GameObject[] objToBeInstantiate;

    public void OnEnable()
    {
        //////for destroyed object
        for (int k = 0; k < objToBeDestroyed.Length; k++)
        {
            if (PlayerPrefs.HasKey("posX" + 0))
            {
                Debug.Log(objToBeDestroyed[k]);
                objToBeDestroyed[k].SetActive(false);
            }
        }
        for (int i = 0; i < objs.Length; i++)
        {
            Debug.Log(PlayerPrefs.GetFloat("posX" + i));

            if (PlayerPrefs.HasKey("posX" + i))
            {
                Vector3 loadposition = new Vector3(PlayerPrefs.GetFloat("posX" + i), PlayerPrefs.GetFloat("posY" + i), PlayerPrefs.GetFloat("posZ" + i));
                objs[i].transform.localPosition = loadposition;
                Debug.Log(loadposition.x);
            }

            //Vector3 loadposition = new Vector3(PlayerPrefs.GetFloat("posX" + i), PlayerPrefs.GetFloat("posY" + i), PlayerPrefs.GetFloat("posZ" + i));
            //objs[i].transform.localPosition = loadposition;
            //Debug.Log(loadposition.x);
        }



       //////for instantiate object
        for (int j = 0; j < objToBeInstantiate.Length; j++)
        {
            if (PlayerPrefs.HasKey("posX" + 0))
            {
                objToBeInstantiate[j].SetActive(true);
            }
        } 

    }

    public void LoadPos()
    {
       for(int i = 0; i < objs.Length; i++)
        {
            Vector3 loadposition = new Vector3(PlayerPrefs.GetFloat("posX" + i), PlayerPrefs.GetFloat("posY" + i), PlayerPrefs.GetFloat("posZ" + i));
          //  objs[i].transform.localPosition = loadposition;
           // Debug.Log(loadposition.x);
        }
    }

    public void SavePos()
    {
        for (int i = 0; i < objs.Length; i++)
        {
            Vector3 saveposition = objs[i].transform.localPosition;
            PlayerPrefs.SetFloat("posX" + i, objs[i].transform.localPosition.x);
            PlayerPrefs.SetFloat("posY" + i, objs[i].transform.localPosition.y);
            PlayerPrefs.SetFloat("posZ" + i, objs[i].transform.localPosition.z);
            PlayerPrefs.Save();
           // Debug.Log(PlayerPrefs.GetFloat("posX" + i));
        }
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
            SavePos();
            Debug.Log("OnApplicationFocus" + hasFocus);
        }
        else
        {
            Debug.Log("OnApplicationFocus" + hasFocus);
        }
       
    }

    void OnApplicationPause(bool pauseStatus)
    { 
        if(pauseStatus == true)
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("OnApplicationPause" + pauseStatus);
        }
        else
        {
            //SavePos();
            Debug.Log("onapplicationpause" + pauseStatus);
        }
    }

    
}
