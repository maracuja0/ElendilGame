using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinEnemy : BaseEmeny
{
    public PlayerController target; 
    public float lookRadius = 10f;
    public float attackRadius = 3f;
    public float attackDelay = 0.2f;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float attackTimer = 0f; 

    public bool isAttacking = false;

    public Rigidbody2D rb;
    public GameObject gun;
    public Transform spawnPoint;

    new void Start()
    {
        base.Start();
        base.damage = 2;
        base.spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<PlayerController>();
    }

    new void Update()
    {
        base.Update();

        float distance = Vector2.Distance(transform.position, target.transform.position);

        // Если игрок находится в радиусе атаки, следуем за ним
        if (distance <= lookRadius)
        {
            Vector2 direction = (target.transform.position - transform.position).normalized;

            // Поворот в направлении игрока
            float angle = Mathf.Atan2(direction.y + 0.15f, direction.x) * Mathf.Rad2Deg - 90f;
            gun.transform.rotation = Quaternion.Euler(0f, 0f, angle);

            // Движение в направлении игрока, пока не достигнута дистанция атаки
            if (distance > attackRadius)
            {
                rb.velocity = direction * moveSpeed;
            }
            else
            {
                rb.velocity = Vector2.zero;
                Attack();
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        
    }

    private void Attack(){
        if (!isAttacking)
        {
            isAttacking = true;
            EnemyBullet bulletScript = bulletPrefab.GetComponent<EnemyBullet>();
            bulletScript.SetDamage(damage);
            bulletScript.SetSpeed(10);
            GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);

            // Задержка между атаками
            Invoke(nameof(ResetAttack), attackDelay);
        }
    }
    private void ResetAttack()
    {
        isAttacking = false;
    }
}
