using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : EnemyBase
{
    [Space(20)]
    [SerializeField] private bool isDeath;
    [SerializeField] private int HP;
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [Space(20)]
    [SerializeField] private float chaseRange;
    [SerializeField] private bool isChasing;

    private Vector3 startPosition;
    private Transform playerTransform;
    private Vector3 originScale;
    private bool canAttack;
    protected override void Awake()
    {
        base.Awake();
        startPosition = transform.position;
        playerTransform = HeroKnight.Instant.transform;
        originScale = transform.localScale;
    }
    // Start is called before the first frame update
    void Start()
    {
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDeath)
            return;

        float distance = Vector2.Distance(transform.position, playerTransform.position);

        if (isChasing)
        {
            anim.SetBool("Move", true);
            Chasing();

            if (distance > chaseRange)
            {
                isChasing = false;

                Move(startPosition, speed);
                transform.localScale = new Vector3(originScale.x * ((transform.position.x >= startPosition.x) ? -1 : 1), originScale.y, originScale.z);
                if (transform.position == startPosition)
                {
                    anim.SetBool("Move", false);
                }
            }
        }
        else
        {
            if (distance <= chaseRange)
            {
                isChasing = true;
            }
            
            
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
        throw new System.NotImplementedException();
    }

    public override void TakeDamage(int damage)
    {
        HP -= damage;

        if (HP <= 0)
        {
            Death();
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
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
