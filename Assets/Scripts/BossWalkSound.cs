using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWalkSound : MonoBehaviour
{
    AudioSource walkSound;

    private void Start()
    {
        walkSound = GetComponent<AudioSource>();
    }

    void WalkSound()
    {
        walkSound.Play();
    }
}
