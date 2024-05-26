using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float projectileDamage;
    Rigidbody2D rb;
    [SerializeField] private float maxTime;
    private float currTime;
    GameObject player;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        currTime = maxTime;
        transform.Rotate(new Vector3(0, 0, -90));
        transform.localScale = new Vector3(1.5f, 2f, 1);
    }

    private void Update()
    {
        currTime -= Time.deltaTime;

        if (currTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void GetShooter(GameObject _player)
    {
        player = _player;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Health>().GetPlayer(player);
            collision.gameObject.GetComponent<Health>().TakeDamage(projectileDamage);
            player.GetComponent<PlayerController>().CallItemOnHit(collision.gameObject.GetComponent<Health>());
            player.GetComponent<PlayerController>().CallItemOnAnyHit(this);
            //gameObject.SetActive(false);
        }

        else
        {
            player.GetComponent<PlayerController>().CallItemOnAnyHit(this);
        }
    }

    public void SetDamage(float _damage)
    {
        projectileDamage = _damage;
    }
}
