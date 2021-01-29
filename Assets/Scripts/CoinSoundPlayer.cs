using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSoundPlayer : MonoBehaviour
{
    AudioSource coin;
    public AudioClip coinGet;

    // Start is called before the first frame update
    void Start()
    {
        coin = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        coin.PlayOneShot(coinGet);
    }
}
