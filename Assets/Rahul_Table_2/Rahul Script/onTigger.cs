using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onTigger : MonoBehaviour
{
   
    public Animator animator; // Reference to the Animator component

    private void OnTriggerEnter(Collider other)
    {
        /*        if (other.CompareTag("Player")) // Adjust the tag to match the object that triggers the animation
                {
                    // Play the desired animation state by its name
                    animator.Play("one" ,-1,0f);
                    Debug.log
                }*/
        if (other.name == "Player")
        {
            animator.Play("one");
        }
    }
}

  

