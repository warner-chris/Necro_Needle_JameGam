using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


//-------------------------------------- More Dots, More Dots, More Dots----------------------------------------------------------------------

public class BleedDotItem : Item
{
    //Maybe change to hemorraging effect like elden ring
    public const int maxStacks = 999;
    private float tickDamage = 0.5f;
    private float dotTimer = 3;

    public override string GiveName()
    {
        return "Bleed Damage Item";
    }
    public override void OnHit(PlayerController _player, Health _enemyHealth, int _stacks)
    {
        if (_stacks >= maxStacks)
        {
            _stacks = maxStacks;
        }
        _enemyHealth.StartBleedDot(tickDamage, _stacks, dotTimer);
    }
}

public class ContagionItem : Item
{
    GameObject effect;
    private float baseTime = 1.2f;
    private float stacksMultiplier = 1.3f;
    public const int maxStacks = 999;
    private float tickDamage = 0.5f;
    private float dotTimer = 3;

    public override string GiveName()
    {
        return "Contagion Item";
    }
    public override void OnHit(PlayerController _player, Health _enemyHealth, int _stacks)
    {
        if (_stacks >= maxStacks)
        {
            _stacks = maxStacks;
        }

        float rand =  Random.Range(1 + (_stacks * stacksMultiplier), 100);
        
        if (rand >= 60)
        {
            _enemyHealth.StartPoisonDot(tickDamage, _stacks, dotTimer);
        }
    }

    public override void OnKill(GameObject _enemy, int _stacks)
    {
        if (_stacks >= maxStacks)
        {
            _stacks = maxStacks;
        }

        effect = (GameObject)Resources.Load("ItemEffects/Poison", typeof(GameObject));
        GameObject poisonObj = GameObject.Instantiate(effect, _enemy.transform.position, Quaternion.Euler(Vector3.zero));
        poisonObj.GetComponent<PoisonGas>().SetVariables(baseTime + ((_stacks - 1) * stacksMultiplier), tickDamage, _stacks, dotTimer);
    }
}
//----------------------------------------------Okay Stop Dots--------------------------------------------------------------------------------