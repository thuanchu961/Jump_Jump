using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float JumpForce = 100f;
    [SerializeField] bool isGround;

    public AnimControll_base animController;

    Animator anim;

    Collider2D colli;
    Rigidbody2D rigi;
    Vector2 movement = Vector2.zero;

    public int extraJumps;
    // Start is called before the first frame update
    void Start()
    {
        rigi = this.GetComponent<Rigidbody2D>();
        colli = this.GetComponent<Collider2D>();
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Moving();
        ChangeAnim();
    }

    public void Moving()
    {
        if (GameManager.instance.isAlive == false)
            return;

        isGround = GroundCheck();

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = rigi.velocity.y;
        Vector2 scale = this.transform.localScale;
        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            movement.x += speed * Time.deltaTime;
            scale.x = Mathf.Abs(scale.x);
        }
        else if(Input.GetAxisRaw("Horizontal") < 0)
        {
            movement.x -= speed * Time.deltaTime;
            scale.x = -Mathf.Abs(scale.x);
        }

        this.transform.localScale = scale;

        if (isGround)
        {
            extraJumps = 1;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if( extraJumps > 0)
            {
                rigi.AddForce(new Vector2(0, JumpForce));
                extraJumps--;
                isGround = false;
            }
            else if(isGround && extraJumps == 0)
            {
                rigi.AddForce(new Vector2(0, JumpForce));
                isGround = false;
            }
            
        }

        rigi.velocity = movement;

    }

    public void ChangeAnim()
    {
       
        if (isGround)
        {
            if (rigi.velocity.x == 0)
            {
                animController.playerState = AnimControll_base.STATE.IDLE;
            }
            else 
            {
                animController.playerState = AnimControll_base.STATE.RUN;
            }
        }
        else
        {
            if (rigi.velocity.y > .1f )
            {
                animController.playerState = AnimControll_base.STATE.JUMP;
                SoundManager.Instant.PlaySound("jumping");
            }
            //else if (rigi.velocity.y > .1f && extraJumps > 0)
            //{
            //    animController.playerState = AnimControll_base.STATE.DOUBLEJUMP;
            //}
            else if(rigi.velocity.y < -.1f)
            {
                animController.playerState = AnimControll_base.STATE.FALL;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }

        if(collision.gameObject.tag == "Traps")
        {
            Death();
        }
    }
    bool GroundCheck()
    {
        float lenRay = 0.15f;
        RaycastHit2D[] hits = new RaycastHit2D[10];
        colli.Cast(Vector2.down, hits, lenRay, true);
        foreach (RaycastHit2D h in hits)
        {
            if(h.collider != null)
            {
                if(h.collider.gameObject.tag == "Ground")
                    return true;
            }
        }

        return false;
    }

    public void Death()
    {
        GameManager.instance.isAlive = false;
        animController.playerState = AnimControll_base.STATE.DEATH;
        SoundManager.Instant.PlaySound("death");

        GameManager.instance.RestartLevel();
   
    }

    
    
}
