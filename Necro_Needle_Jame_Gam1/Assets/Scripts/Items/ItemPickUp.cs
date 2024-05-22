using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item item;
    public Items itemDrop;

    private void Start()
    {
        item = AssignItem(itemDrop);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController _player = collision.GetComponent<PlayerController>();
            AddItem(_player);
            _player.CallItemOnPickUp();
            Destroy(this.gameObject);
        }
    }

    public void AddItem(PlayerController _player)
    {
        foreach (ItemList i in _player.items)
        {
            if (i.name == item.GiveName())
            {
                i.stacks++;
                return;
            }
        }

        _player.items.Add(new ItemList(item, item.GiveName(), 1));
    }



    public Item AssignItem(Items _itemToAssign)
    {
        switch (_itemToAssign)
        {
                    default: return null;
        }

    }

    public enum Items
    {

    }
}
