using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : Entity
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Die();
        }
    }
}
