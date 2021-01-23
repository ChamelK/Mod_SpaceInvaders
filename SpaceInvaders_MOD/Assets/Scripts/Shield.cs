using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public Sprite[] states;

    private int health;
    private SpriteRenderer sr;

    private void Start()
    {
        health = 4;
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("EnemyBullet"))
                {
            Destroy(collision.gameObject);
            health--;

            if (health <= 0)
                Destroy(gameObject);
            else
                sr.sprite = states[health - 1];
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
        }
    }

   
}
