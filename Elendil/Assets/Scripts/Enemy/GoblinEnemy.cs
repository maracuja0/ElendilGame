using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinEnemy : BaseEmeny
{
    public Transform target; 
    public float lookRadius = 10f;
    public float attackRadius = 2f;
    public float attackDelay = 0.5f;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float attackTimer = 0f; 

    public Rigidbody2D rb;
    public GameObject gun;
    public Transform spawnPoint;

    new void Start()
    {
        base.Start();
        base.damage = 2;
        rb = GetComponent<Rigidbody2D>();
    }

    new void Update()
    {
        base.Update();


        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius) {

            Vector2 direction = (target.position - transform.position).normalized;
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
        

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            gun.transform.rotation = Quaternion.Euler(0f, 0f, angle);

            attackTimer += Time.deltaTime;

            if (distance <= attackRadius) {
                rb.MovePosition(rb.position + direction * 0 * Time.fixedDeltaTime);
                if (attackTimer >= attackDelay) {
                    Attack();
                    attackTimer = 0f;
                }
            }
        }
    }

    private void Attack(){
        EnemyBullet bulletScript = bulletPrefab.GetComponent<EnemyBullet>();
        bulletScript.SetDamage(damage);
        bulletScript.SetSpeed(10);
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
