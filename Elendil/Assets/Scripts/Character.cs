using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed;
    public int maxHealth;
    private int currentHealth;
    private int attackDamage;

    public Character(float speed, int maxHealth,int attackDamage){
        this.speed = speed;
        this.maxHealth = maxHealth;
        this.attackDamage = attackDamage;
        this.currentHealth = attackDamage;
    }
    
    public void move(){
        
    }

    public void takeDamage(){

    }
}
