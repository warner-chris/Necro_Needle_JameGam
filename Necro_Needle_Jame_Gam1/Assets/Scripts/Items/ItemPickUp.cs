using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item item;
    public Items itemDrop;
    private GameObject enemy;
    private ItemDrop itemDropperScript;

    private void Start()
    {
        item = AssignItem(itemDrop);
        itemDropperScript = FindObjectOfType<ItemDrop>();
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
            //Healing Items
            case Items.HealOverTimeItem:
                return new HealOverTimeItem();
            //Stat Boost Items
            case Items.MaxHealthItem:
                return new MaxHealthItem();
            case Items.AttackPowerItem:
                return new AttackPowerItem();
            case Items.AttackSpeedItem:
                return new AttackSpeedItem();
            case Items.MovementSpeedItem:
                return new MovementSpeedItem();
            case Items.AddDashItem:
                return new AddDashItem();
            //Dot Items
            case Items.BleedDotItem:
                return new BleedDotItem();
            case Items.ContagionItem:
                return new ContagionItem();
            //Projectile Mod Items
            case Items.ExplodingDamageItem:
                return new ExplodingDamageItem();
            //Special Grade
            case Items.IceItem:
                return new IceItem();
            case Items.SpiderWebItem:
                return new SpiderWebItem();
            case Items.RaiseDeadItem:
                return new RaiseDeadItem();
            default: return null;
        }

    }

    public enum Items
    {
        //Healing Items
        HealOverTimeItem,
        //Stat Boost Items
        MaxHealthItem,
        AttackPowerItem,
        AttackSpeedItem,
        MovementSpeedItem,
        AddDashItem,
        //Dot Items
        BleedDotItem,
        ContagionItem,
        //Projectile Mod Items
        ExplodingDamageItem,
        //Special Grade
        IceItem,
        SpiderWebItem,
        RaiseDeadItem
    }
}
