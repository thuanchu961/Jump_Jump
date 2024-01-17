using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : EnemyBase
{
    [SerializeField] private Transform[] points;
    [Space(20)]
    [SerializeField] private bool isDeath;
    [SerializeField] private int HP;
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [Space(20)]
    [SerializeField] private float chaseRange;
    [SerializeField] private bool isChasing;
    [SerializeField] private bool canTakeDamage;

    private Transform targetTransform;
    private Transform playerTransform;
    private Vector3 originScale;
    private bool canAttack;
    protected override void Awake()
    {
        base.Awake();

        playerTransform = HeroKnight.Instant.transform;
        originScale = transform.localScale;
    }
    private void Start()
    {
        canTakeDamage = true;
        canAttack = true;
        targetTransform = points[1];
    }
    private void Update()
    {
        if (isDeath)
            return;

        float distance = Vector2.Distance(transform.position, playerTransform.position);

        if (isChasing)
        {
            Chasing();

            if (distance > chaseRange)
            {
                isChasing = false;
                transform.localScale = new Vector3(originScale.x * ((transform.position.x >= targetTransform.position.x) ? -1 : 1),
                originScale.y, originScale.z);
            }
        }
        else
        {
            if (distance <= chaseRange)
            {
                isChasing = true;
            }

            Patrolling();
        }
    }

    public override void Chasing()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        transform.localScale = new Vector3(originScale.x * ((transform.position.x >= playerTransform.position.x) ? -1 : 1), originScale.y, originScale.z);
    }

    public override void Death()
    {
        isDeath = true;

        anim.SetTrigger("Dead");
    }

    public override void Move(Vector2 targetPosition, float speed)
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    public override void Patrolling()
    {
        Move(targetTransform.position, speed);

        float distance = Vector2.Distance(transform.position, targetTransform.position);

        if (distance < 0.1f)
        {
            targetTransform = (targetTransform == points[1]) ? points[0] : points[1]; //set destination

            transform.localScale = new Vector3(originScale.x * ((transform.position.x >= targetTransform.position.x) ? -1 : 1),
                originScale.y, originScale.z);
        }
    }

    public override void TakeDamage(int damage)
    {
        if (canTakeDamage)
        {
            canTakeDamage = false;
            anim.SetTrigger("Hurt");
            HP -= damage;
            if (HP <= 0)
            {
                Death();
            }
            canTakeDamage = true;
        }
    }
    public void DisableEnemy()
    {
        transform.parent.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canAttack)
        {
            canAttack = false;
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !canAttack)
        {
            canAttack = true;
        }
    }
}
