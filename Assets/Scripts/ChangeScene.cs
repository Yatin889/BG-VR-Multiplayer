using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public float time;
    public void sceneTransition(string sceneName)
    {
        StartCoroutine(delayScene(sceneName));
    }
    IEnumerator delayScene(string sceneName)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
        
        Application.Quit();
    }

}
