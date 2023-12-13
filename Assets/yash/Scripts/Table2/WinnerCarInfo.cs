using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerCarInfo : MonoBehaviour
{
    public float Duration;
    [Space]
    public WheelAttach Car1;
    public WheelAttach Car2;

    [Space]
    public CarMove[] carMove;

    [Space]
    [Header("Sequence. \nWood & Rubber OR Rubber & Wood - 0. \nWood & Steel OR Steel & Wood - 1. \nSteel & Rubber OR Rubber & Steel - 2.")]
    public GameObject[] WinnerCanvas;
    private void Update()
    {
        if (carMove[0].isCompleteTrack && carMove[1].isCompleteTrack)
        {
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(Duration);
        ShowWinnerInfo();
    }
    private void ShowWinnerInfo()
    {
        if(Car1.tag == "Wood" && Car2.tag == "Rubber" || Car1.tag == "Rubber" && Car2.tag == "Wood")
        {
            WinnerCanvas[0].SetActive(true);
        }
        else if (Car1.tag == "Wood" && Car2.tag == "Steel" || Car1.tag == "Steel" && Car2.tag == "Wood")
        {
            WinnerCanvas[1].SetActive(true);
        }
        else if (Car1.tag == "Steel" && Car2.tag == "Rubber" || Car1.tag == "Rubber" && Car2.tag == "Steel")
        {
            WinnerCanvas[2].SetActive(true);
        }
        gameObject.SetActive(false);
    }

    public void DisableCanvas()
    {
        foreach(GameObject canva in WinnerCanvas)
        {
            canva.SetActive(false);
        }
    }
}
