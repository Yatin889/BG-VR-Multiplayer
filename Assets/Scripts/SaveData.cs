using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{
    public static SaveData instance;
    public string SceneName;
    [Space]
    public Transform XR;
    [Space]
    public GameObject[] WelcomeObj;
    [Space]
    public GameObject Podium1;
    public GameObject[] Podiums;
    bool isTable1;
    private void Awake()
    {
/*        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }       
        else
        {
            Destroy(gameObject);
        }   */     
        //  
    }
    void Start()
    {     
        if(PlayerPrefs.GetInt("SceneData") == 1 && SceneManager.GetActiveScene().name == SceneName)
        {
            Vector3 Position = new Vector3(PlayerPrefs.GetFloat("PosX"), PlayerPrefs.GetFloat("PosY"), PlayerPrefs.GetFloat("PosZ"));

            if(WelcomeObj[0])
            {
                foreach (GameObject obj in WelcomeObj)
                {
                    obj.SetActive(false);
                }

                if(PlayerPrefs.HasKey("PosX"))
                {
                    XR.position = Position;
                }

                PlayerPrefs.SetInt("SceneData", 0);
             
                PlayerPrefs.DeleteKey("PosX");
                PlayerPrefs.DeleteKey("PosY");
                PlayerPrefs.DeleteKey("PosZ");
            }  
        }
        else
        {
            foreach (GameObject obj in Podiums)
            {
                if (!isTable1)
                {
                    obj.SetActive(true);
                }
                else
                {
                    Podium1.SetActive(true);
                    obj.SetActive(true);
                }
            }
        }
    }
    public void SetSceneData(bool SetPos)
    {
        PlayerPrefs.SetInt("SceneData", 1);

        if(SetPos)
        {
            isTable1 = true;
            PlayerPrefs.SetFloat("PosX", XR.position.x);
            PlayerPrefs.SetFloat("PosY", XR.position.y);
            PlayerPrefs.SetFloat("PosZ", XR.position.z);
        }
    }

  /*  private void OnDestroy()
    {
        PlayerPrefs.SetInt("SceneData", 0);
        PlayerPrefs.DeleteKey("PosX");
        PlayerPrefs.DeleteKey("PosY");
        PlayerPrefs.DeleteKey("PosZ");
    }*/
}
