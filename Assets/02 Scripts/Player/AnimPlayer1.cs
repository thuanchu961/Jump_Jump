using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPlayer1 : AnimControll_base
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < (int)AnimControll_base.STATE.len; i++)
        {
            if((int)playerState == i)
            {
                anim.SetBool(playerState.ToString(), true);
            }
            else
            {
                AnimControll_base.STATE stateEnum = (AnimControll_base.STATE)i;
                anim.SetBool(stateEnum.ToString(), false);
            }
        }
    }
}
