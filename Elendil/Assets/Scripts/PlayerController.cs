using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    public Animator anim;
    public FixedJoystick joystick;
    private Vector2 direction;

    public int maxHealth = 10;
    protected float currentHealth = 0f;

    public int damage = 1;

    // public GameObject gun;
    // public float bulletForce = 10f;

    // public GameObject bulletPrefab;
    // public Transform spawnPoint;

    // public GameObject enemy;

    // public GameObject[] enemyes = new GameObject[3];

    // public List<GameObject> Enemyes = new List<GameObject>();
    // private GameObject target;

    // Start is called before the first frame update
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
        // Debug.Log(enemy.transform.position);

        // for(int i = 0; i < enemyes.Length; i++ ){
        //     if(Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(enemyes[i].transform.position.x, enemyes[i].transform.position.y)) <
        //     Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(target.transform.position.x, target.transform.position.y))){
        //         target = enemyes[i];
        //     }
        // }

        // Vector3 autoAim = (target.transform.position - transform.position).normalized;
        // float angle = Mathf.Atan2(autoAim.y, autoAim.x) * Mathf.Rad2Deg -90f;
        // gun.transform.rotation = Quaternion.Euler(0f, 0f, angle);
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
            // this.Die();
        }
    }

    // protected virtual void OnAttacked(Collider2D collider) {}
    protected virtual void Die() {
        Destroy(gameObject);
    }

    public int GetDamage(){
        return damage;
    }
    void FixedUpdate()
    {
        move();
    }

    private void move(){
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
        
    }

    // public void shot(){
    //     Instantiate(bulletPrefab, spawnPoint.position, gun.transform.rotation);
    // }

    // private void takeDamage(){

    // }

    // public void Shoot(){
    //     GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, gun.transform.rotation);
    //     Rigidbody2D Bullet = bullet.GetComponent<Rigidbody2D>();
    //     Bullet.AddForce(spawnPoint.up * bulletForce, ForceMode2D.Impulse);
    // }

    //МБ ПРИГОДИТСЯ
    

        // Vector3 difference = target.transform.position - transform.position;
        // float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        // weapon.transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);

        //Instantiate(bullet, shot_pos.transform.position, weapon.transform.rotation);
}
