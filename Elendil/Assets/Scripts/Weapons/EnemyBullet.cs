using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damage = 2;
    public float speed = 10f;
    public Rigidbody2D rb;
    
    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    public int GetDamage()
    {
        return this.damage;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Tag.PLAYER || collision.gameObject.tag == Tag.WALL)
        {
            Destroy(gameObject);
        }else{
            Destroy(gameObject, 2f);
        }
    }
}
