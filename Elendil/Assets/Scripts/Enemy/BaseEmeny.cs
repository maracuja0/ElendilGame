using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEmeny : MonoBehaviour
{
    /*
    Блок переменных, отвечающиай за здоровье врага
    */
    public int maxHealth = 10;
    protected float currentHealth = 0f;

    /*
    Блок переменных, отвечающиай за зпередвижение врага
    */
    public float moveSpeed = 2f;

    public float damage = 1f;

    // Сюда надо вставить текстовое поле для вывода HP врага
    // public Slider healthbar;

    //функция получения текущего здоровья героя
    public float health
    {
        get { return currentHealth; }
    }

    // Use this for initialization
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
    }

    // protected virtual void OnAttacked(Collider2D collider) {}
    protected virtual void Die() {
        Destroy(gameObject);
    }
}
