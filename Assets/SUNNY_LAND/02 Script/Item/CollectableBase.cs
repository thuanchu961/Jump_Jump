using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollectableBase : MonoBehaviour
{
    protected Animator anim;
    protected AudioSource audioSource;
    protected virtual void Awake()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    public abstract void OnCollected();
    public abstract void DestroyItem();
}
