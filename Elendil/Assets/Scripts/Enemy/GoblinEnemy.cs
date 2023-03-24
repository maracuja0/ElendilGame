using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinEnemy : BaseEmeny
{
    /*
    Блок переменных, отвечающиай за здоровье врага
    */
    public Transform target; 
    public float lookRadius = 10f;
    public float attackRadius = 2f;
    public float attackDelay = 1f;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float attackTimer = 0f; 

    /*
    Блок переменных, отвечающиай за вращение оружия и спавн снарядов
    */
    public GameObject gun;
    public Transform spawnPoint;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        base.damage = 2;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();


        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius) {

            Vector3 direction = (target.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            gun.transform.rotation = Quaternion.Euler(0f, 0f, angle);

            attackTimer += Time.deltaTime;

            if (distance <= attackRadius) {
                if (attackTimer >= attackDelay) {
                    Attack();
                    attackTimer = 0f;
                }
            }
        }
    }

    private void Attack(){
        // Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // // Задаем скорость пули
        // Bullet bulletScript = bullet.GetComponent<Bullet>();
        // bulletScript.speed = bulletSpeed;
        // bulletScript.SetDamage(this.damage);

        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
    }
}
