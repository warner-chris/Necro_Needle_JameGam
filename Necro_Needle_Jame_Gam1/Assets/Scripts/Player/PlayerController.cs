using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Progress;

public class PlayerController : MonoBehaviour
{
    public List<ItemList> items = new List<ItemList>();
    [SerializeField] private float procTimer;
    [SerializeField] private GameObject needle;

    private int maxNumberOfDashes = 1;
    private int dashesUsed = 0;
    [SerializeField] private float dashMaxTime;
    private float dashCurrTime;
    [SerializeField] private float dashSpeed;
    private bool isDashing = false;

    [SerializeField] private float dashCooldownMax;
    private float dashCooldownCurr = 0;

    private PlayerHealth health;
    Rigidbody2D rb;

    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;

    Vector2 movement;
    Vector2 lookDirection;

    private Transform spawnPoint;

    private void Awake()
    {
        health = GetComponent<PlayerHealth>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine(CallItemUpdate());
    }

    private void Update()
    {
        HasIFrames();
        CheckDashTime();
        CheckDashCooldown();
    }

    //----------------------------------------------------Item Stuffs------------------------------------------------------------------------
    private IEnumerator CallItemUpdate()
    {
        foreach (ItemList i in items)
        {
            i.item.Update(this, i.stacks);
        }

        yield return new WaitForSeconds(procTimer);
        StartCoroutine(CallItemUpdate());
    }

    public void CallItemOnPickUp()
    {
        var lastItem = items.Last();
        lastItem.item.OnPickUp(this, lastItem.stacks);
    }

    //-----------------------------------------------Non-Health Stat Changes------------------------------------------------------------------

    public void IncreaseMovementSpeed(float _gainz)
    {
        movementSpeed += _gainz;
    }

    public void IncreaseNumberOfDashes(int _gainz)
    {
        maxNumberOfDashes += _gainz;
    }

    //----------------------------------------------------Upkeep Stuffs-----------------------------------------------------------------------
    private void HasIFrames()
    {
        if (health.GetiFrames())
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    private void CheckDashCooldown()
    {
        dashCooldownCurr -= Time.deltaTime;
        if (dashCooldownCurr <= 0 && dashesUsed > 1)
        {
            dashesUsed--;
            dashCooldownCurr = dashCooldownMax;
        }

        else if (dashCooldownCurr <= 0 && dashesUsed > 0)
        {
            dashesUsed--;
        }
    }

    private void CheckDashTime()
    {
        if (isDashing)
        {
            dashCurrTime -= Time.deltaTime;
            if (dashCurrTime <= 0)
            {
                rb.velocity = Vector2.zero;
                needle.GetComponent<NeedleController>().MoveWithPlayer(Vector2.zero);
                isDashing = false;
            }
        }
    }

    //---------------------------------------------------Movement Stuffs---------------------------------------------------------------------
    public void Move(InputAction.CallbackContext context)
    {
        if (!isDashing)
        {
            movement = context.ReadValue<Vector2>();
            Vector2 appliedMovement = new Vector2(movement.x * (Time.deltaTime + movementSpeed), movement.y * (Time.deltaTime + movementSpeed));
            rb.velocity = appliedMovement;
            needle.GetComponent<NeedleController>().MoveWithPlayer(appliedMovement);
        }
    }

    public void Look(InputAction.CallbackContext context)
    {
        lookDirection = context.ReadValue<Vector2>();

        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, lookDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, (rotationSpeed * Time.fixedDeltaTime));
        transform.rotation = rotation;
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if (!isDashing)
        {
            if (dashCooldownCurr <= 0 || dashesUsed < maxNumberOfDashes)
            {
                dashCooldownCurr = dashCooldownMax;
                dashCurrTime = dashMaxTime;
                Vector2 appliedDash = new Vector2(movement.x * dashSpeed, movement.y * dashSpeed);
                rb.velocity = appliedDash;
                needle.GetComponent<NeedleController>().MoveWithPlayer(appliedDash);
                health.StartiFrames();
                isDashing = true;
                dashesUsed++;
            }
        }
    }
}