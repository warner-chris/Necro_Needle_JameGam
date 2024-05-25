using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonGas : MonoBehaviour
{
    private float damage = 0.5f;
    private int stacks = 4;
    private float time = 3;
    private float upTime = 999;

    public void SetVariables(float _timer, float _damage, int _stacks, float _dotTime)
    {
        upTime = _timer;
        damage = _damage;
        stacks = _stacks;
        time = _dotTime;
        
    }

    private void Update()
    {
        upTime -= Time.deltaTime;

        if (upTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Health>().StartPoisonDot(damage, stacks, time);
        }
    }
}
