using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class ItemList
{
    public Item item;
    public string name;
    public int stacks;

    public ItemList(Item _newItem, string _newName, int _newStacks)
    {
        item = _newItem;
        name = _newName;
        stacks = _newStacks;
    }
}