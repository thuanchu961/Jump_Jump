using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    private Image heartImage;
    private Animator anim;
    private void Awake()
    {
        heartImage = GetComponent<Image>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableHeart()
    {
        anim.SetTrigger("Minus");
    }
}
