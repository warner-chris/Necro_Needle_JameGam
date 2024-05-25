using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//-------------------------------------Attack Related Pew Pew-------------------------------------------------------------
public class AttackPowerItem : Item
{
    public const int maxStacks = 999;
    private float extraDamage = 0.3f;
    private float stacksMultiplier = 1.3f;

    public override string GiveName()
    {
        return "Attack Power Item";
    }
    public override void OnPickUp(PlayerController _player, int _stacks)
    {
        if (_stacks < maxStacks)
        {
            _player.GetComponent<PlayerShoot>().IncreaseProjectileDamage(extraDamage, _stacks * stacksMultiplier);
        }
    }
}

public class AttackSpeedItem : Item
{
    public const int maxStacks = 10;
    private float attackSpeedChange = 0.2f;

    public override string GiveName()
    {
        return "Attack Speed Item";
    }
    public override void OnPickUp(PlayerController _player, int _stacks)
    {
        if (_stacks >= maxStacks)
        {
            _stacks = maxStacks;
        }
        _player.GetComponent<PlayerShoot>().IncreaseAttackSpeed(attackSpeedChange);
    }
}

//---------------------------------Sustain - I Will Survive!!-----------------------------------------------------------
public class MaxHealthItem : Item
{
    public const int maxStacks = 999;
    private float maxHealthChange = 5;

    public override string GiveName()
    {
        return "Max Health Item";
    }
    public override void OnPickUp(PlayerController _player, int _stacks)
    {
        if (_stacks < maxStacks)
        {
            _player.GetComponent<PlayerHealth>().GainMaxHealth(maxHealthChange);
        }
    }
}

//-----------------------------------------Shmoovement-------------------------------------------------------------
public class MovementSpeedItem : Item
{
    public const int maxStacks = 10;
    private float speedIncrease = 0.5f;
    private float stacksMultiplier = 1.2f;

    public override string GiveName()
    {
        return "Movement Speed Item";
    }

    public override void OnPickUp(PlayerController _player, int _stacks)
    {
        if (_stacks >= maxStacks)
        {
            _stacks = maxStacks;
        }
        _player.IncreaseMovementSpeed(speedIncrease, _stacks + stacksMultiplier);
    }
}

public class AddDashItem : Item
{
    public const int maxStacks = 3;
    private int dashesToAdd = 1;


    public override string GiveName()
    {
        return "Add Dash Item";
    }

    public override void OnPickUp(PlayerController _player, int _stacks)
    {
        if (_stacks < maxStacks)
        {
            _player.IncreaseNumberOfDashes(dashesToAdd);
        }
    }
}