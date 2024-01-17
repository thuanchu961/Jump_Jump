using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTop : MonoBehaviour
{
    private Rigidbody2D rigid;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void DropSpike()
    {
        rigid.bodyType = RigidbodyType2D.Dynamic;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(1);
            
        }
        gameObject.SetActive(false);
    }
}
