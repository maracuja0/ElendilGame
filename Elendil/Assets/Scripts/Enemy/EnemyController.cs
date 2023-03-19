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
    public Transform target; // игрок, за которым следит враг
    public float lookRadius = 10f; // радиус, в котором враг обнаруживает игрока
    public float attackRadius = 2f; // радиус, в котором враг атакует игрока
    public float attackDelay = 2f; // задержка перед атакой
    public float moveSpeed = 2f; // скорость передвижения врага
    public GameObject bulletPrefab;
    public float bulletSpeed;

    public GameObject gun;
    
    public Transform spawnPoint;

    // private float attackTimer = 0f;

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

            // if (distance <= attackRadius) {
            //     if (attackTimer >= attackDelay) {
            //         Attack();
            //         attackTimer = 0f;
            //     }
            // }
        }
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = 0;
    }

    // void Attack()
    // {
    //     GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, gun.transform.rotation);
    //     Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

    //     // Задаем скорость пули
    //     Bullet bulletScript = bullet.GetComponent<Bullet>();
    //     bulletScript.speed = bulletSpeed;
        
    //     rb.velocity = bulletSpeed * spawnPoint.up;
    // }
}