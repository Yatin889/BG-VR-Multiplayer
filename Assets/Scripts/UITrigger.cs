using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITrigger : MonoBehaviour
{
    public Image[] images;

    public int currentIndex = 0;

    public Button Next;
    public Button Previous;

    private void Update()
    {
        if (currentIndex == 0)
        {
            Previous.gameObject.SetActive(false);
        }

        else if ((currentIndex == images.Length - 1))
        {
            Next.gameObject.SetActive(false);
        }

        else
        {
            Previous.gameObject.SetActive(true);
            Next.gameObject.SetActive(true);

        }
    }

    public void NextUI()
    {
    
        currentIndex = (currentIndex + 1);
        ShowNextUI();
    }

    public void PreviousUI()
    {
       
        currentIndex = (currentIndex - 1) ;
        ShowPreviousUI();
    }

    public void ShowNextUI()
    {

        for (int i = 0; i < images.Length; i++)
        {
            
            images[i].gameObject.SetActive(i == currentIndex);

            if(currentIndex >= images.Length)
            {
                images[images.Length].gameObject.SetActive(true);
            }

           
        }
    }

    public void ShowPreviousUI()
    {
        
        for (int i = images.Length-1 ; i >= 0; i--)
        {
          
            images[i].gameObject.SetActive(i == currentIndex);

            if (i == 0 || currentIndex < 0)
            {
                images[0].gameObject.SetActive(true);
            }

          
        }
    }


}
