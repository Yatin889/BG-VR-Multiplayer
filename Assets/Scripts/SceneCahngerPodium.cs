using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCahngerPodium : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Sand()
    {
        SceneManager.LoadScene("Sand");
    }
    public void Snow()
    {
        SceneManager.LoadScene("Snow");
    }
    public void Water()
    {
        SceneManager.LoadScene("Water");
    }
    public void FrictionLab()
    {
        SceneManager.LoadScene("CopiedModels");
    }
    public void SceneChangeLoader(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
