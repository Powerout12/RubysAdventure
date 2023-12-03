using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmAnimals : MonoBehaviour
{
    public AudioClip collisionSound;

    private AudioSource audioSource;

    void Start()
    {
        // Add an AudioSource component to the GameObject
        audioSource = gameObject.AddComponent<AudioSource>();

        // Assign the collision sound to the AudioSource
        audioSource.clip = collisionSound;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision involves the other object
        if (collision.gameObject.CompareTag("Ruby"))
        {
            // Play the collision sound
            audioSource.Play();
        }
    }
}