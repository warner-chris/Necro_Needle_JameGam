using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyGeneral : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    private GameObject player;
    [SerializeField] private LayerMask enemyLayer;
    private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D boxCollider;
    Transform target;

    [SerializeField] private float baseSpeed;
    public float speed;

    private Health health;
    [SerializeField] private float damage;

    public bool isRaisedDead = false;

    private bool speedChanged = false;
    private float speedChangedTimer;

    private int xDirection = 1;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();
        player = GameObject.FindWithTag("Player");
        target = player.transform;
        speed = baseSpeed;
    }
    
    private void Update()
    {
        if (speedChanged)
        {
            speedChangedTimer -= Time.deltaTime;

            if (speedChangedTimer <= 0)
            {
                speedChanged = false;
                ResetSpeed();
            }
        }
        if (isRaisedDead)
        {
            ChaseEnemy();
        }
        else
        {
            Chase();
        }
    }


    private void Chase()
    {
        // Get the direction and distance to the target object
        Vector2 direction = target.position - transform.position;
        float distance = direction.magnitude;

        // Normalize the direction vector to have a magnitude of 1
        if (distance > 0)
        {
            direction /= distance;
        }

        // Move towards the target object by adding velocity in the direction of the target object
        rb.velocity = new Vector2(direction.x * (Time.fixedDeltaTime + speed), direction.y * (Time.fixedDeltaTime + speed));

        if (target.position.x > transform.position.x)
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }

        else if (target.position.x < transform.position.x)
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!isRaisedDead)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            }
            else if (collision.gameObject.CompareTag("Thrall"))
            {
                collision.gameObject.GetComponent<Health>().TakeDamage(damage / 2);
            }
            else return;
        }
        else if (collision.gameObject.CompareTag("Enemy") & isRaisedDead)
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }

    public void ChangeToRaisedDead()
    {
        GetComponent<SpriteRenderer>().color = Color.blue;
        gameObject.tag = "Thrall";
        health.HasRaised();
        isRaisedDead = true;
    }

    private void IsUnderPlayerControl()
    {
        ChaseEnemy();
    }

    private void ChaseEnemy()
    {
        GameObject enemy = GameObject.FindWithTag("Enemy");
        if (enemy != null)
        {
            target = enemy.transform;
            Vector2 direction = target.position - transform.position;
            float distance = direction.magnitude;
            if (distance > 0)
            {
                direction /= distance;
            }
            rb.velocity = new Vector2(direction.x * (Time.fixedDeltaTime + speed), direction.y * (Time.fixedDeltaTime + speed));
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void Webbed(float _timer)
    {
        speed = 0;
        speedChangedTimer = _timer;
        speedChanged = true;
    }

    public void OnIce(float _timer)
    {
        speed /= 4;
        speedChangedTimer = _timer;
        speedChanged = true;
    }

    public void ResetSpeed()
    {
        speed = baseSpeed;
    }

    public void IsDead()
    {
        speed = 0;
    }

}
/*private void OnDrawGizmos()
{
    Gizmos.color = Color.red;
    Gizmos.DrawSphere(circleCollider.bounds.center, sightSize);
}*/
