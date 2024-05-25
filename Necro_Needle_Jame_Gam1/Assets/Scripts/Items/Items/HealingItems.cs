using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//------------------------------------------------Healing Items--------------------------------------------------
public class HealOverTimeItem : Item
{
    public const int maxStacks = 999;
    private float gainz = 5;
    private float stacksMultiplier = 2;

    public override string GiveName()
    {
        return "Heal Over Time Item";
    }

    public override void Update(PlayerController _player, int _stacks)
    {
        if (_stacks >= maxStacks)
        {
            _stacks = maxStacks;
        }
        _player.GetComponent<PlayerHealth>().GainHealth(gainz + ((_stacks - 1) * stacksMultiplier));
    }
}