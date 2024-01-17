using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    protected Rigidbody2D rigi;
    protected Collider2D colli;
    protected Animator anim;
    protected SpriteRenderer spriteRenderer;
    protected virtual void Awake()
    {
        rigi = GetComponent<Rigidbody2D>();
        colli = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public abstract void Move(Vector2 targetPosition, float speed);
    public abstract void Patrolling();
    public abstract void Chasing();
    public abstract void TakeDamage(int damage);
    public abstract void Death();
}