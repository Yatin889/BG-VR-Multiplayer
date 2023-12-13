using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRRigWalkingAudio : MonoBehaviour
{
    public AudioClip walkingAudioClip;
    private AudioSource audioSource;
    private bool isMoving = false;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isMoving = false;
        if (audioSource != null)
        {
            audioSource.clip = walkingAudioClip;
        }
    }
    private void Update()
    {
        // Check vertical input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        // Check if moving in any direction (forward, backward, left, or right)
        isMoving = (horizontalInput != 0 || verticalInput != 0);
        if (isMoving && !audioSource.isPlaying)
        {
          //  audioSource.clip = walkingAudioClip;
            audioSource.Play();
        }
        if (!isMoving)
        {
            audioSource.Stop();
        }
    }
}