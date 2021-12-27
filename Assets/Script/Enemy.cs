using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<Bird>() != null)
        {
            Destroy(gameObject);
        }

        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if(enemy != null)
        {
            return;
        }

        if(collision.GetContact(0).normal.y < -0.5)
        {
            Destroy(gameObject);
        }
    }
}
