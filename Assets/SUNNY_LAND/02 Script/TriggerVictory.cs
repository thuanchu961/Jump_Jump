
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerVictory : MonoBehaviour
{
    private GameManager gameManager;
    private void Awake()
    {
        gameManager = GameManager.Instant;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Victory());
        }
    }
    IEnumerator Victory()
    {
        yield return new WaitForSeconds(3f);
        gameManager.Victory();
    }
}
