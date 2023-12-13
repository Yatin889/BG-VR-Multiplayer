using UnityEngine;
using UnityEngine.UI;

public class ImageTrueColor : MonoBehaviour
{

    public Image targetImage;
    public float delayBeforeChange;
    public Color enterTriggerColor = Color.green; // Set the color to change when entering the trigger
    public GameObject objectToActivate;

    void Start()
    {
       
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider that entered the trigger is the player (you can customize this condition)
        if (other.CompareTag("Player"))
        {
            // Change the image color to the specified color when entering the trigger
            ChangeImageColor(enterTriggerColor);

            // Activate another GameObject
           /* if (objectToActivate != null)
            {
                ChangeToNextobj();
            }*/
        }
    }

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

    public void ChangeImageColor(Color newColor)
    {
        // Set the color of the Image component
        targetImage.color = newColor;

        // Cancel any previously scheduled invocation and invoke a method to change the color to white after the specified delay
        CancelInvoke("ChangeToNextobj");
        Invoke("ChangeToNextobj", delayBeforeChange);
    }

    public void ChangeToNextobj()
    {
        
        objectToActivate.SetActive(true);
       
    }
}

