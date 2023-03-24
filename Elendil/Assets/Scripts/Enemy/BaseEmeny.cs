using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEmeny : MonoBehaviour
{
    /*
    Блок переменных, отвечающиай за здоровье врага
    */
    public int maxHealth = 10;
    protected int currentHealth = 0;

    /*
    Блок переменных, отвечающиай за зпередвижение врага
    */
    public float moveSpeed = 2f;

    public int damage = 1;

    // Сюда надо вставить текстовое поле для вывода HP врага
    // public Slider healthbar;

    /*
    /Геттеры
    */
    public int GetDamage(){
        return this.damage;
    }

    public int GetHealth(){
        return this.currentHealth;
    }

    /*
    /Сеттеры
    */
    public void SetDamage(int damage){
        this.damage = damage;
    }

    protected void Start()
    {
        currentHealth = maxHealth;
        // healthbar.maxValue = maxHealth;
    }

     // Update is called once per frame
    protected void Update()
    {
        // healthbar.value = this.health;
        // healthbar.gameObject.SetActive(healthbar.value < maxHealth);
    }

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

        if (collision.tag == Tag.BULLET)
        {
            TakeDamage(1);
        }else if(collision.tag == Tag.ARC_LIGHTNING){
            TakeDamage(5);
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

    protected void TakeDamage(int damage)
    {
        // this.OnAttacked(collider);
        if (currentHealth > damage)
        {
            currentHealth -= damage;
        } else
        {
            currentHealth = 0;
            this.Die();
        }
    }

    // protected virtual void OnAttacked(Collider2D collider) {}
    private void Die() {
        Destroy(gameObject);
    }
}
