using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenSounds : MonoBehaviour
{
    public AudioClip chickenHitSound;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void Hit()
    {
        PlaySound(chickenHitSound);
    }
}
