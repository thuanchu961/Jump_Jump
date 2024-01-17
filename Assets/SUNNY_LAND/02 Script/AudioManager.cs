using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public float SoundVolume { get; set; }
    public float MusicVolume { get; set; }
    private void Awake()
    {
        SoundVolume = 0.5f;
        MusicVolume = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MuteSound(bool mute)
    {
        SoundVolume = (mute ? 0f : 0.5f);
    }
    public void MuteMusic(bool mute)
    {
        MusicVolume = (mute ? 0f : 0.7f);
    }
}
