using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float damage;
    [SerializeField] private float rotationSpeed;
    private Rigidbody2D rb;
    private Vector3 target;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.RotateAround(player.transform.localPosition, Vector3.back, Time.deltaTime * rotationSpeed);
    }

    public void MoveWithPlayer(Vector2 _applyMovement)
    {
        rb.velocity = _applyMovement;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }

    public void IncreaseRotationSpeed(float _gainz)
    {
        rotationSpeed += _gainz;
    }

    public void SetInactive()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
    }

    public void SetActive()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
    }
}