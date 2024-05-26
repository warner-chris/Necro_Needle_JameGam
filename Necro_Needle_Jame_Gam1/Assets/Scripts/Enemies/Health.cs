using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private GameObject itemDropObj;
    [SerializeField] private float startingHealth;
    private bool dotApplied = false;
    private GameObject player;
    private bool isDead = false;

    private float currentHealth = 999;
    private float procDotInterval = 1;

    private float poisonTickDamage = 0;
    private int poisonStacks = 0;
    private float poisonTimerMax;
    private float poisonTimerCurr = 4;

    private int hemorrhageStacks = 0;
    private float hemorrhageDecrementTimer = 1;
    private bool hemorrhageDecrementStarted = false;

    private float bleedTickDamage = 0;
    private int bleedStacks = 0;
    private float bleedTimerMax;
    private float bleedTimerCurr = 4;

//------------------------------------------------Base Logic---------------------------------------------------
    private void Start()
    {
        currentHealth = startingHealth;
    }

    private void Update()
    {
        HasDied();
        CanDie();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
    }

    private void HasDied()
    {
        if (currentHealth <= 0)
        {
            if (player!= null)
            {
                player.GetComponent<PlayerController>().CallItemOnKill(this.gameObject);
            }
            this.GetComponent<BoxCollider2D>().enabled = false;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            itemDropObj.GetComponent<ItemDrop>().IncrementKills(gameObject);
            gameObject.GetComponent<EnemyGeneral>().IsDead();
        }
    }

    public void HasRaised()
    {
        currentHealth = startingHealth;
    }

    public void CanDie()
    {
        if (!gameObject.GetComponent<EnemyGeneral>().isRaisedDead && isDead)
        {
            Destroy(this.gameObject);
        }
    }

    public float GetStartingHealth()
    {
        return startingHealth;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public void GetPlayer(GameObject _player)
    {
        player = _player;
    }


 //---------------------------------------------------------MORE DOTS--------------------------------------------------------------
    public void StartBleedDot(float _damage, int _stacks, float _time)
    {
        bleedStacks+= _stacks;
        bleedTickDamage = _damage;
        bleedTimerMax = _time;
        if (!dotApplied)
        {
            dotApplied = true;
            StartCoroutine(DotTimer());
        }
    }

    public void StartPoisonDot(float _damage, int _stacks, float _time)
    {
        poisonStacks += _stacks;
        poisonTickDamage = _damage;
        poisonTimerMax = _time;
        if (!dotApplied)
        {
            dotApplied = true;
            StartCoroutine(DotTimer());
        }
    }

    private IEnumerator DotTimer()
    {

        TakeDamageOverTime();
        CheckDotTimer();
        yield return new WaitForSeconds(procDotInterval);

        if (bleedStacks > 0 || poisonStacks > 0)
        {
            StartCoroutine(DotTimer());
        }
        else
        {
            dotApplied = false;
        }
    }

    private void TakeDamageOverTime()
    {
        currentHealth -= (bleedTickDamage * bleedStacks);
        currentHealth -= (poisonTickDamage * poisonStacks);
    }

    private void CheckDotTimer()
    {
        if (bleedStacks > 0)
        {
            bleedTimerCurr -= Time.deltaTime;
        }
        if (poisonStacks > 0)
        {
            poisonTimerCurr -= Time.deltaTime;
        }

        if (bleedTimerCurr <= 0)
        {
            DecrementBleedStacks();
        }
        if (poisonTimerCurr <= 0)
        {
            DecrementPoisonStacks();
        }
    }

    private void DecrementBleedStacks()
    {
        if (bleedStacks > 0)
        {
            bleedStacks--;
        }
        bleedTimerCurr = bleedTimerMax; 
    }

    private void DecrementPoisonStacks()
    {
        if (poisonStacks > 0)
        {
            poisonStacks--;
        }
        poisonTimerCurr = poisonTimerMax;
    }

//-------------------------------------------------STOP IT'S HEMORRHAGE TIME!------------------------------------------------------

    public void AddHemorrhageStacks(int _stacksToAdd)
    {
        hemorrhageStacks += _stacksToAdd;

        if (hemorrhageStacks == (startingHealth/4))
        {
            currentHealth -= (startingHealth/3);
            _stacksToAdd = 0;
        }

        if (!hemorrhageDecrementStarted)
        {
            hemorrhageDecrementStarted = true;
            StartCoroutine(RemoveHemorrhageStacks());
        }
    }

    private IEnumerator RemoveHemorrhageStacks()
    {

        yield return new WaitForSeconds(hemorrhageDecrementTimer);

        if (hemorrhageStacks > 0)
        {
            hemorrhageStacks--;
            StartCoroutine(RemoveHemorrhageStacks());
        }
        else
        {
            hemorrhageDecrementStarted = false;
        }
    }
}