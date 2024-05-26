using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] public Transform firepoint;
    [SerializeField] public GameObject projectilePrefab;
    [SerializeField] public GameObject needleObj;

    [SerializeField] private float bulletDamageBase;
    private float bulletDamage;
    [SerializeField] public float bulletForce;
    [SerializeField] private float cooldownMaxTime;
    private float cooldownCurrTime;
    private bool canShoot = true;

    private void Awake()
    {
        bulletDamage = bulletDamageBase;
    }

    private void Update()
    {
        if (cooldownCurrTime < cooldownMaxTime)
        {
            IncrementShotTime();
        }

        else if (cooldownCurrTime >= cooldownMaxTime)
        {
            canShoot = true;
            needleObj.GetComponent<NeedleController>().SetActive();
        }

        OldShoot();
    }

    private void ApplyShot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firepoint.position, firepoint.rotation);
        projectile.SetActive(true);
        projectile.GetComponent<Projectile>().GetShooter(this.gameObject);
        projectile.GetComponent<Projectile>().SetDamage(bulletDamage);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);
    }

//-----------------------------------------------Changes From Items----------------------------------------
    public void IncreaseAttackSpeed(float _gainz)
    {
        cooldownMaxTime -= _gainz;
    }

    public void IncreaseProjectileDamage(float _damageGainz, float _mulitplier)
    {
        bulletDamageBase += _damageGainz;
        bulletDamage = (bulletDamageBase * _mulitplier);
    }
    
    public float GetCurrentDamage()
    {
        return bulletDamage;
    }
    //-------------------------------------------General UpKeep-----------------------------------------------

    private void IncrementShotTime()
    {
        cooldownCurrTime += Time.deltaTime;
    }

//------------------------------------------------Controls-----------------------------------------------
    public void Shoot()
    {
        if (canShoot)
        {
            canShoot = false;
            cooldownCurrTime = 0;
            needleObj.GetComponent<NeedleController>().SetInactive();
            ApplyShot();
        }
    }

    private void OldShoot()
    {
        if (canShoot && Input.GetKey("space"))
        {
            canShoot = false;
            cooldownCurrTime = 0;
            needleObj.GetComponent<NeedleController>().SetInactive();
            ApplyShot();
        }
    }
}