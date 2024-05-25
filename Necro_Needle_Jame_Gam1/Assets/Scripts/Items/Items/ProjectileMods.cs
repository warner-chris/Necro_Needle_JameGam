using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExplodingDamageItem : Item
{
    GameObject effect;
    public const int maxStacks = 5;
    private float stacksMultiplier = 1.3f;
    private float additionalDamage = 5;

    public override string GiveName()
    {
        return "Exploding Damage Item";
    }
    public override void OnHit(PlayerController _player, Health _enemy, int _stacks)
    {
        if (_stacks >= maxStacks)
        {
            _stacks = maxStacks;
        }

        float damage = _player.gameObject.GetComponent<PlayerShoot>().GetCurrentDamage();
        effect = (GameObject)Resources.Load("ItemEffects/Explosion", typeof(GameObject));
        GameObject explosionObj = GameObject.Instantiate(effect, _enemy.transform.position, Quaternion.Euler(Vector3.zero));
        explosionObj.GetComponent<Explosion>().SetVariables(((_stacks - 1) * damage * stacksMultiplier) + additionalDamage);
    }
}