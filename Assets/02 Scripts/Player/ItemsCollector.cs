using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsCollector : MonoBehaviour
{
    public Text countText;
    private int colleted = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Collectable"))
        {
            Destroy(collision.gameObject);
            SoundManager.Instant.PlaySound("collect item");
            colleted++;
            countText.text = "Items : " + colleted;
        }    
    }
}
