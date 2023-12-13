using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarted : MonoBehaviour
{

    private void OnEnable()
    {
        PlayerPrefs.SetString("GameStart", "GSTD");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
