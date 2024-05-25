using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine.InputSystem.Layouts;
using System;

public class IceItem : Item
{
    GameObject effect;
    private float baseTime = 3.5f;
    public const int maxStacks = 999;
    private float stacksMultiplier;

    public override string GiveName()
    {
        return "Ice Item";
    }
    public override void OnHit(PlayerController _player, Health _enemy, int _stacks)
    {

        if (_stacks >= maxStacks)
        {
            _stacks = maxStacks;
        }
        int rand = Random.Range(1, 100);
        if (rand + (_stacks * stacksMultiplier) > 40)
        {
            effect = (GameObject)Resources.Load("ItemEffects/Ice", typeof(GameObject));
            GameObject iceObj = GameObject.Instantiate(effect, _enemy.transform.position, Quaternion.Euler(Vector3.zero));
            iceObj.GetComponent<IcePatch>().SetTimer(baseTime + ((_stacks - 1) * stacksMultiplier));
        }
    }
}

public class SpiderWebItem : Item
{
    GameObject effect;
    public const int maxStacks = 999;
    private float stacksMultiplier = 1f;
    private float timeMultiplier = 1.5f;
    private float baseTimer = 1f;

    public override string GiveName()
    {
        return "Spider Web Item";
    }

    public override void OnHit(PlayerController _player, Health _enemy, int _stacks)
    {
        int rand = Random.Range(1, 100);

        if (_stacks >= maxStacks)
        {
            _stacks = maxStacks;
        }
        
        if (rand + (_stacks * stacksMultiplier) > 70)
        {
            effect = (GameObject)Resources.Load("ItemEffects/Web", typeof(GameObject));
            GameObject webObj = GameObject.Instantiate(effect, _enemy.transform.position, Quaternion.Euler(Vector3.zero));
            webObj.GetComponent<SpiderWeb>().SetTimer(baseTimer + ((_stacks - 1) * timeMultiplier));
        }
    }
}

public class RaiseDeadItem : Item
{
    public const int maxStacks = 999;
    private float stacksMultiplier;

    public override string GiveName()
    {
        return "Raise Dead Item";
    }
    public override void OnKill(GameObject _enemy, int _stacks)
    {
        int rand = Random.Range(1, 100);
        if (_stacks >= maxStacks)
        {
            _stacks = maxStacks;
        }
        if (rand + (_stacks * stacksMultiplier) > 50)
        {
            GameObject zombie = GameObject.Instantiate(_enemy);
            zombie.GetComponent<EnemyGeneral>().ChangeToRaisedDead();
        }
    }
}