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
    public Vector2 direction;
    public int maxHealth = 10;
    public float currentHealth = 0f;

    public int damage = 10;

    public Death_menu death;
    public GameObject spawnPoint;
    public int level;

    private const string key = "mainSave";
    private SaveManager saveManager;

    public GameButtonsController buttonsController;

    public bool canRun = true;

    public bool canAttack = false, canArcLightning = false, canThunder = false;

    public int GetDamage(){
        return this.damage;
    }

    public void SetDamage(int damage){
        this.damage = damage;
    }

    void Start()
    {
        saveManager = FindObjectOfType<SaveManager>();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        if(PlayerPrefs.HasKey(key)){
            saveManager.LoadGame(key);
            if(transform.position == new Vector3(0f, 0f, 0f)){
                transform.position = spawnPoint.transform.position;
            }
            if(canAttack){
                buttonsController.setActiveAttack();
            }
        }else{
            canArcLightning = false;
            canThunder = false;
            transform.position = spawnPoint.transform.position;
            buttonsController.setDeActiveAttack();
        }
        
    }

    void Update()
    {
        if(canRun){
            direction.x = joystick.Horizontal;
            direction.y = joystick.Vertical;

            anim.SetFloat("MoveX", direction.x);
            anim.SetFloat("MoveY", direction.y);
            anim.SetFloat("Speed", direction.sqrMagnitude);
        }else{
            anim.SetFloat("MoveX", 0);
            anim.SetFloat("MoveY", 0);
            anim.SetFloat("Speed", 0);
        }
    }

    void FixedUpdate()
    {
        if(canRun){
            move();
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Tag.ENEMY_BULLET)
        {
            TakeDamage(collision.gameObject.GetComponent<EnemyBullet>().GetDamage());
        }
    }
    protected void TakeDamage(int damage)
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
    }
    private void Die() {
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
        this.canAttack = saveData.canAttack;
        this.canArcLightning = saveData.canArcLightning;
        this.canThunder = saveData.canThunder;
    }
}
