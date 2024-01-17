using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioManager audioManager;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioManager = AudioManager.Instant;
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource.loop = true;
        audioSource.Play();
    }
    private void Update()
    {
        audioSource.volume = audioManager.MusicVolume;
    }
}
