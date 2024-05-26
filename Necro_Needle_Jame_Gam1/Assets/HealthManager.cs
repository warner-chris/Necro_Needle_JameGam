using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public GameObject player;
    private PlayerHealth health;
    public Image healthBar;
    public float healthAmount;
    public float healthTotal;
    // Start is called before the first frame update
    void Start()
    {
        health = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        SetMaxHealth();
        SetCurrentHealth();
        UpdateHealthBar();
    }

    private void SetMaxHealth()
    {
        healthTotal = health.GetPlayerMaxHealth();
        //Debug.Log("Total " + healthTotal);
    }
    private void SetCurrentHealth()
    {
        healthAmount = health.GetCurrentHealth();
        //Debug.Log("Curent " + healthAmount);
    }

    private void UpdateHealthBar()
    {
        healthBar.fillAmount = healthAmount / healthTotal;
    }
}
