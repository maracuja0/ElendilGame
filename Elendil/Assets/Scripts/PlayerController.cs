using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    public Animator anim;
    public FixedJoystick joystick;
    private Vector2 direction;
    public int maxHealth = 10;
    public float currentHealth = 0f;

    public int damage = 1;

    public Death_menu death;
    public GameObject spawnPoint;
    public int level;

    /*
    /Геттеры
    */
    public int GetDamage(){
        return this.damage;
    }

    /*
    /Сеттеры
    */
    public void SetDamage(int damage){
        this.damage = damage;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        transform.position = spawnPoint.transform.position;
    }

    void Update()
    {
        direction.x = joystick.Horizontal;
        direction.y = joystick.Vertical;

        anim.SetFloat("MoveX", direction.x);
        anim.SetFloat("MoveY", direction.y);
        anim.SetFloat("Speed", direction.sqrMagnitude);
    }

    void FixedUpdate()
    {
        move();
    }

    //[SerializeField] private HealthBar healthBar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Tag.ENEMY_BULLET)
        {
            TakeDamage(collision.gameObject.GetComponent<EnemyBullet>().GetDamage());
        }
    }
    protected void TakeDamage(float damage)
    {
        Debug.Log(damage);
        if (currentHealth > damage)
        {
            currentHealth -= damage;
        } else
        {
            currentHealth = 0;
            this.Die();
        }
        //healthBar.UpdateHealthBar(maxHealth, currentHealth);
    }
    private void Die() {
        //установить состояние аниматора на смерть
        // gameObject.SetActive(false);
        death.Death();
    }

    private void move(){
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }

    public void LoadData(PlayerData saveData){
        transform.position = new Vector3(saveData.position.x, saveData.position.y, saveData.position.z);
        this.level = saveData.level;
        this.currentHealth = saveData.health;
        this.damage = saveData.damage;
    }
}
