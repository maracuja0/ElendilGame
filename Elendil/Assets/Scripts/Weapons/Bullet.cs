using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int damage;
    public float speed = 10f;
    public Rigidbody2D rb;
    public PlayerController player;
    
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        damage = player.damage;
        rb.velocity = transform.up * speed;
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }
    public int GetDamage()
    {
        return this.damage;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Tag.ENEMY || collision.gameObject.tag == Tag.WALL)
        {
            Destroy(gameObject);
        }else{
            Destroy(gameObject, 1f);
        }
    }

}
