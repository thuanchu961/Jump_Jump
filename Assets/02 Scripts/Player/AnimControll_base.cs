using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControll_base : MonoBehaviour
{
    public STATE playerState = STATE.IDLE;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public enum STATE
    {
        IDLE,
        RUN,
        JUMP,
        FALL,
       // DOUBLEJUMP,
       DEATH,
        len
    }
}
