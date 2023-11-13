using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    private AudioSource audioSource;
    private bool IsMovingV;
    private bool IsMovingH;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {

        if (Input.GetAxis("Vertical") != 0) IsMovingV = true; // better use != 0 here for both directions
        else IsMovingV = false;

        if (Input.GetAxis("Horizontal") != 0) IsMovingH = true; // better use != 0 here for both directions
        else IsMovingH = false;

        if ((IsMovingV || IsMovingH) && !audioSource.isPlaying) audioSource.Play(); // if player is moving and audiosource is not playing play it
        if (!IsMovingV && !IsMovingH) audioSource.Stop(); // if player is not moving and audiosource is playing stop it
    }
}