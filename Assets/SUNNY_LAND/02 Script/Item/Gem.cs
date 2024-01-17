using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : CollectableBase
{
    private int value;
    private AudioManager audioManager;
    private GameManager gameManager;
    protected override void Awake()
    {
        base.Awake();
        audioManager = AudioManager.Instant;
        gameManager = GameManager.Instant;
    }
    // Start is called before the first frame update
    void Start()
    {
        value = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void DestroyItem()
    {
        Destroy(gameObject);
    }

    public override void OnCollected()
    {
        gameManager.IncreaseGem(value);
        anim.SetTrigger("Collected");
        audioSource.volume = audioManager.SoundVolume;
        audioSource.loop = false;
        audioSource.Play();
    }

}
