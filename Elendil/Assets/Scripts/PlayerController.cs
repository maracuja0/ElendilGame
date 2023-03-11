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

    public GameObject gun;
    public float bulletForce = 10f;

    public GameObject bulletPrefab;
    public Transform spawnPoint;

    public GameObject enemy;

    public GameObject[] enemyes = new GameObject[3];
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        target = enemyes[0];
        direction.x = joystick.Horizontal;
        direction.y = joystick.Vertical;

        anim.SetFloat("MoveX", direction.x);
        anim.SetFloat("MoveY", direction.y);
        anim.SetFloat("Speed", direction.sqrMagnitude);
        Debug.Log(enemy.transform.position);

        for(int i = 0; i < enemyes.Length; i++ ){
            if(Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(enemyes[i].transform.position.x, enemyes[i].transform.position.y)) <
            Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(target.transform.position.x, target.transform.position.y))){
                target = enemyes[i];
            }
        }

        Vector3 autoAim = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(autoAim.y, autoAim.x) * Mathf.Rad2Deg -90f;
        gun.transform.rotation = Quaternion.Euler(0f, 0f, angle);
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

    public void Shoot(){
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, gun.transform.rotation);
        Rigidbody2D Bullet = bullet.GetComponent<Rigidbody2D>();
        Bullet.AddForce(spawnPoint.up * bulletForce, ForceMode2D.Impulse);
    }

    //МБ ПРИГОДИТСЯ
    

        // Vector3 difference = target.transform.position - transform.position;
        // float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        // weapon.transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);

        //Instantiate(bullet, shot_pos.transform.position, weapon.transform.rotation);
}
