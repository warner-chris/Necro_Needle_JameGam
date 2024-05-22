using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[System.Serializable]
public abstract class Item
{
    public abstract string GiveName();

    public virtual void OnPickUp(PlayerController _playerHealth, int _stacks)
    {
    }

    public virtual void Update(PlayerController _player, int _stacks)
    {
    }

}





