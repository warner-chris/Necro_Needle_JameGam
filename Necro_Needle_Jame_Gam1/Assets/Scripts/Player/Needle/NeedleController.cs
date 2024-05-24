using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float fireSpeed;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.RotateAround(player.transform.localPosition, Vector3.back, Time.deltaTime * rotationSpeed);
    }

    private void Fire()
    {
    
    }

    private void Return()
    {
        
    }

    public void MoveWithPlayer(Vector2 _applyMovement)
    {
        rb.velocity = _applyMovement;
    }
}
