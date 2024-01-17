using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anim;
    private GameManager gameManager;
    [Header("Player properties")]
    [SerializeField] private int maxHP;
    [SerializeField] private int currentHP;
    private void Awake()
    {
        gameManager = GameManager.Instant;
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        anim.SetTrigger("Hurt");
        UIManager.Instant.DecreseHeart();
        if(currentHP <= 0)
        {
            Death();
        }
    }
    public void Death()
    {
        HeroKnight.Instant.isDeath = true;
        //death
        anim.SetBool("noBlood", false);
        anim.SetTrigger("Death");

        gameManager.Defeat();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            collision.gameObject.GetComponent<CollectableBase>().OnCollected();
        }
    }
}
