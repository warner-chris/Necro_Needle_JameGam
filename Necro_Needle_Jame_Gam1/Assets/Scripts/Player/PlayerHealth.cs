using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth  : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    private float currentHealth = 999;
    private bool iFrames = false;
    [SerializeField] private float iFrameTimerMax;
    private float iFrameTimerCurrent;

    private void Start()
    {
        currentHealth = startingHealth;
    }

    private void Update()
    {
        HasDied();

        if (iFrameTimerCurrent <= iFrameTimerMax)
        {
            iFrameTimerCurrent += Time.deltaTime;
        }
        else
        {
            iFrames = false;
        }
    }

    public void TakeDamage(float _damage)
    {
        if (!iFrames)
        {
            currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
            if (currentHealth > 0)
            {
                iFrameTimerCurrent = iFrameTimerMax;
                iFrames = true;
            }
        }
    }

    public void GainHealth(float _gainz)
    {
        if (currentHealth + _gainz <= startingHealth)
        {
            currentHealth += _gainz;
        }
        else
        {
            currentHealth = startingHealth;
        }
    }

    public void GainMaxHealth(float _gainz)
    {
        startingHealth += _gainz;
    }

    private void HasDied()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
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

    public bool GetiFrames()
    {
        return iFrames;
    }

    public void StartiFrames()
    {
        iFrames = true;
        iFrameTimerCurrent = 0;
    }
}
