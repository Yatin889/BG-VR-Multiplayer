using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerQuizButton : MonoBehaviour
{
 
    public GameObject animatedObject;
    public GameObject uiCanvas;
    public string animationName = "YourAnimationName";

    private Animator anim;
    private bool hasEntered = false;

    void Start()
    {
        anim = animatedObject.GetComponent<Animator>();
        uiCanvas.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasEntered)
        {
            // Trigger the animation
            anim.Play(animationName);

            // Display the UI
            uiCanvas.SetActive(true);

            // Set a flag to prevent repeated triggering
            hasEntered = true;
        }
    }
}

