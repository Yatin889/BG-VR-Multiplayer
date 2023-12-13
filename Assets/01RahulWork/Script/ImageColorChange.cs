using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageColorChange : MonoBehaviour
{
  
   public Image targetImage;
    public float delayBeforeChange;
    public Color enterTriggerColor = Color.red; // Set the color to change when entering the trigger

    void Start()
    {
        InitializeTargetImage();
        ChangeImageColor(Color.red);
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider that entered the trigger is the player (you can customize this condition)
        if (other.CompareTag("Player"))
        {
            // Change the image color to the specified color when entering the trigger
            ChangeImageColor(enterTriggerColor);
        }
    }

    /*void OnTriggerExit(Collider other)
    {
        // Check if the collider that exited the trigger is the player (you can customize this condition)
        if (other.CompareTag("Player"))
        {
            // Change the image color to white when exiting the trigger
            ChangeImageColor(Color.white);
        }
    }*/

    void InitializeTargetImage()
    {
        if (targetImage == null)
        {
            targetImage = GetComponent<Image>();

            if (targetImage == null)
            {
                Debug.LogError("Image component not found. Please assign the targetImage in the Inspector or ensure the script is attached to an object with an Image component.");
                return;
            }
        }
    }

    void ChangeImageColor(Color newColor)
    {
        // Set the color of the Image component
        targetImage.color = newColor;

        // Cancel any previously scheduled invocation and invoke a method to change the color to white after the specified delay
        CancelInvoke("ChangeToWhite");
        Invoke("ChangeToWhite", delayBeforeChange);
    }

    void ChangeToWhite()
    {
        // Change the color of the Image component to white
        ChangeImageColor(Color.white);
    }
}

