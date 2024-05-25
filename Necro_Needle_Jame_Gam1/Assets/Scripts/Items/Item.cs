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
    
    public virtual void OnAnyHit(PlayerController _player, Projectile _projectile, int _stacks)
    {
    }

    public virtual void OnHit(PlayerController _player, Health _enemyHealth, int _stacks)
    {
    }

    public virtual void OnKill(GameObject _enemy, int _stacks)
    {
    }
}





