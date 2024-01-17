using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private GameObject muteSoundObject;
    [SerializeField] private GameObject muteMusicObject;
    private GameManager gameManager;
    private AudioManager audioManager;
    private bool muteSound, muteMusic;
    private void Awake()
    {
        gameManager = GameManager.Instant;
        audioManager = AudioManager.Instant;

        muteMusicObject.SetActive(false);
        muteSoundObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SoundButton()
    {
        muteSound = !muteSound;

        muteSoundObject.SetActive(muteSound);

        audioManager.MuteSound(muteSound);
    }
    public void MusicButton()
    {
        muteMusic = !muteMusic;

        muteMusicObject.SetActive(muteMusic);

        audioManager.MuteMusic(muteMusic);
    }
    public void ResumeButton()
    {
        gameManager.ContinueGame();
    }
    public void RestartButton()
    {
        gameManager.RestartLevel();
    }
    public void ExitButton()
    {
        gameManager.ExitLevel();
    }
}
