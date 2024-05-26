using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemDrop : MonoBehaviour
{
    [SerializeField] GameObject[] itemsList;
    private int killsTotal;
    private int kills = 0;
    private int killThreshold = 5;

    public void IncrementKills(GameObject _pos)
    {
        killsTotal++;
        kills++;
        if (kills >= killThreshold)
        {
            kills = 0;
            killThreshold += 5;
            DropItem(_pos);
        }
        else
        {
            Destroy(_pos);
        }
    }

    private void DropItem(GameObject _pos)
    {
        int rand = Random.Range(0, itemsList.Length);
        GameObject item = Instantiate(itemsList[rand], _pos.transform);
        item.GetComponent<ItemPickUp>().SetEnemy(_pos);
        Debug.Log(item.transform);
    }
}
