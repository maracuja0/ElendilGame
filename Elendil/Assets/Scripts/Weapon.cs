using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    // public float fireRate = 0.2f;
    public float range = 10f;
    public int damage = 10;
    // public Canvas fireButtonCanvas;

    // private float nextFireTime = 0f;
    private GameObject nearestEnemy;

    void Update()
    {
        // Находим ближайшего врага
        nearestEnemy = FindNearestEnemy();

        if (nearestEnemy != null)
        {
            // Направляем оружие на ближайшего врага
            Vector2 direction = nearestEnemy.transform.position - transform.position;
            transform.up = direction;

            // Стреляем, если нажата кнопка выстрела и прошло достаточно времени с предыдущего выстрела
            // if (fireButtonCanvas.enabled && Time.time >= nextFireTime)
            // {
            //     Shoot();
            //     nextFireTime = Time.time + fireRate;
            // }
        }
    }

    GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearestEnemy = null;
        float nearestEnemyDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < nearestEnemyDistance)
            {
                nearestEnemy = enemy;
                nearestEnemyDistance = distance;
            }
        }

        return nearestEnemy;
    }

    public void Shoot()
    {
        // Создаем пулю и задаем ей скорость
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.speed = 10f;

        // // Наносим урон врагу, если пуля столкнулась с врагом
        // RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, transform.up, range);
        // if (hitInfo.collider != null && hitInfo.collider.isTrigger)
        // {
        //     EnemyController enemy = hitInfo.collider.gameObject.GetComponent<EnemyController>();
        //     enemy.TakeDamage(damage);
        // }
    }
}

