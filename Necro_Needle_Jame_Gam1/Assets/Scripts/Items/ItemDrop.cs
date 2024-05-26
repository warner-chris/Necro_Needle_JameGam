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
    private int killThreshold = 5;
    private bool itemSpawning = false;
    private float elapsedTime;
    public AudioManager audioManager;
    private PlayerController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }


    private void Update()
    {
        kills = player.killCountTotal;
        Debug.Log(kills);
        if (kills > killThreshold)
        {
            Debug.Log("Spawned");
            kills = 0;
            killThreshold += 3;
            DropItem();

            audioManager.PlaySFX(audioManager.itemDrop);
        }
    }

    private void DropItem()
    {
        int rand = Random.Range(0, itemsList.Length);
        GameObject item = Instantiate(itemsList[rand]);
        item.transform.position = new Vector2(player.gameObject.transform.position.x, player.gameObject.transform.position.y + 1);
        
        item.SetActive(true);
    }  
}
