using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemDrop : MonoBehaviour
{
    [SerializeField] GameObject[] itemsList;
    private int killsTotal = 0;
    private int kills = 0;
    private int killThreshold = 10;
    private bool itemSpawning = false;
    private float elapsedTime;
    public AudioManager audioManager;


    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime % 60 == 0)
        {
            DropItem(gameObject);
            audioManager.PlaySFX(audioManager.itemDrop);
        }
    }

    public void IncrementKills(GameObject _pos)
    {
        if (!itemSpawning)
        {
            kills++;
            killsTotal++;
        }
        if (kills >= killThreshold && !itemSpawning)
        {
            itemSpawning = true;
            kills = 0;
            //DropItem(_pos);
            killThreshold += 5;
        }
        else if (!itemSpawning)
        {
            _pos.GetComponent<Health>().CanDie();
        }
    }

    private void DropItem(GameObject _pos)
    {
        int rand = Random.Range(0, itemsList.Length);
        GameObject item = Instantiate(itemsList[rand], _pos.transform);
        item.GetComponent<ItemPickUp>().SetEnemy(_pos);
    }

    public void ItemDespawn()
    {
        itemSpawning = false;
    }    
}
