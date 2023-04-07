using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    }

    // Update is called once per frame
    void Update()
    {
        // target = enemyes[0];
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

    [SerializeField] private HealthBar healthBar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Collider2D collider = collision;
        // if (collider.tag == Tag.BULLET)
        // {
        //     Bullet bullet = collider.GetComponent<Bullet>();
        //     if (bullet != null)
        //     {
        //         this.TakeDamage(bullet.GetDamage(), collider);
        //     }
        // }

        if (collision.tag == Tag.ENEMY_BULLET)
        {
            TakeDamage(1);
        }

        //if (collider.tag == Tag.SWORD)
        // {
        //     SwordAttack swordAttack = collider.GetComponent<SwordAttack>();
        //     if (swordAttack.attacking)
        //     {
        //         Debug.Log("Attacked" + swordAttack.baseWeapon.damage);
        //         swordAttack.attacking = false;
        //         this.GotDamage(swordAttack.baseWeapon.damage, collider);
        //     }
        // }
    }
    protected void TakeDamage(float damage)
    {
        // this.OnAttacked(collider);
        if (currentHealth >= damage)
        {
            currentHealth -= damage;
        } else
        {
            currentHealth = 0;
            this.Die();
        }
        healthBar.UpdateHealthBar(maxHealth, currentHealth);
    }

    // protected virtual void OnAttacked(Collider2D collider) {}
    private void Die() {
        //установить состояние аниматора на смерть
        // gameObject.SetActive(false);
        death.Death();
    }

    

    private void move(){
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
        
    }
}
