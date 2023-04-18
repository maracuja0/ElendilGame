using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEmeny : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth = 0;
    public float moveSpeed = 2f;
    public int damage = 1;

    public bool isInvulnerable = false;
    public int GetDamage(){
        return this.damage;
    }

    public int GetHealth(){
        return this.currentHealth;
    }

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
        if(!isInvulnerable){
            if (collision.tag == Tag.BULLET)
            {
                TakeDamage(collision.GetComponent<Bullet>().GetDamage());
            }else if(collision.tag == Tag.ARC_LIGHTNING)
            {
                TakeDamage(collision.GetComponent<LightningBullet>().GetDamage());
            }
        }
        
    }

    public void TakeDamage(int damage)
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

    private void Die() {
        Destroy(gameObject);
    }
    public IEnumerator MakeInvulnerable(float invulnerableTime)
    {
        isInvulnerable = true;
        yield return new WaitForSeconds(invulnerableTime);
        isInvulnerable = false;
    }
}
