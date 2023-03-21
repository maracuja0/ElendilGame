using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float damage = 2f;
    public float speed = 10f;
    public Rigidbody2D rb;
    
    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }
    public float GetDamage()
    {
        return this.damage;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Tag.ENEMY || collision.gameObject.tag == Tag.WALL)
        {
            Destroy(gameObject);
        }else{
            Destroy(gameObject, 2f);
        }
    }

}
