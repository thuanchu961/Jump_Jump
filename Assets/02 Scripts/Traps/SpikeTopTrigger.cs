using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTopTrigger : MonoBehaviour
{
    [SerializeField] private List<GameObject> spikeTopList;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        count = spikeTopList.Count;
    }
    private void Update()
    {
        foreach (var item in spikeTopList)
        { 
            if (!item.activeSelf) 
            {
                count--;
            }  
        }

        if (count == 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach (var spike in spikeTopList)
            {
                spike.GetComponent<SpikeTop>().DropSpike();
            }
            
        }
    }
}
