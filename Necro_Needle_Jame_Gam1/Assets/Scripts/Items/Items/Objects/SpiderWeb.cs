using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpiderWeb : MonoBehaviour
{
    private float timer;
    private bool done = false;

    private void Awake()
    {
        timer = 999;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(this.gameObject);
        }
        
    }

    public void SetTimer(float _timer)
    {
        timer = _timer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<EnemyGeneral>().Webbed(timer);
        }
    }

}
