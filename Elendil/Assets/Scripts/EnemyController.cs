using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject enemy;

    public int maxHealth = 4;
    public int currentHealth;

    // public Transform target;
    // public float moveSpeed = 5f;
    // public float attackRange = 2f;
    // public GameObject bulletPrefab;
    // public float bulletSpeed = 10f;
    // public float fireRate = 1f;


    public Transform target; // игрок, за которым следит враг
    public float lookRadius = 10f; // радиус, в котором враг обнаруживает игрока
    public float attackRadius = 2f; // радиус, в котором враг атакует игрока
    public float attackDelay = 1f; // задержка перед атакой
    public float moveSpeed = 2f; // скорость передвижения врага
    // private float attackTimer = 0f;

        

    // private float nextFireTime = 0f;

    void Start()
    {
        currentHealth = maxHealth;
    }
    
    void Update()
    {
        // Направляем врага к игроку
        // Vector3 direction = (target.position - transform.position).normalized;
        // transform.Translate(direction * moveSpeed * Time.deltaTime);


        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius) {

            Vector3 direction = (target.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);
            // agent.SetDestination(target.position);

            if (distance <= attackRadius) {
                

                // if (attackTimer >= attackDelay) {
                //     // атакуем игрока
                //     attackTimer = 0f;
                // }
            }
        }

        // // Если враг достиг игрока, атакуем его
        // if (Vector3.Distance(transform.position, target.position) < attackRange && Time.time >= nextFireTime)
        // {
        //     Attack();
        //     nextFireTime = Time.time + fireRate;
        // }

    }

    public int GetHealth(){
        return currentHealth;
    }

    public void Die(){
        Destroy(gameObject);
    }

    public void TakeDamage(int damage){
        if(currentHealth > damage){
            currentHealth -= damage;
        }else{
            currentHealth = 0;
            this.Die();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Collider2D collider = collision;
        // Bullet bullet = collider.GetComponent<Bullet>();

        // if (bullet != null)
        // {
        //     Debug.Log("Attacked" + 1);
        //     this.TakeDamage(1);
        // }
        if (collision.tag == Tag.BULLET)
        {
            TakeDamage(1);
        }
    }

    // void Attack()
    // {
    //     // Создаем новый объект пули
    //     GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

    //     // Задаем скорость пули
    //     Bullet bulletScript = bullet.GetComponent<Bullet>();
    //     bulletScript.speed = bulletSpeed;

    //     // Направляем пулю на игрока
    //     Vector3 direction = (target.position - transform.position).normalized;
    //     bullet.transform.right = direction;

    //     // Уничтожаем пулю через некоторое время
    //     Destroy(bullet, 2f);
    // }

    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.tag == "Bullet")
    //     {
    //         TakeDamage(1);
    //     }
    // }
}