using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opossum : Entity
{
    public float speed;
    private Vector3 dir;
    private SpriteRenderer sprite;
    

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    void Start()
    {
        dir = transform.right;
    }
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.1f + transform.right * dir.x * 0.1f, 0.1f);

        if (colliders.Length > 1) dir *= -1f;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0.0f;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Die();
        }
        else
        {
            GetDamage();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == FoxMove.Instance.gameObject)
        {
            FoxMove.Instance.GetDamage();
        }
    }
}
