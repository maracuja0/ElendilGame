using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerData
{
    public int level;
    public float health;
    public int damage;
    public Vec3 position;
    public int sceneIndex;
    public bool is_continue = false;

    public bool canAttack, canArcLightning, canThunder;
    
    [System.Serializable]
    public struct Vec3{
        public float x, y, z;

        public Vec3(GameObject checkpoint){
            this.x = checkpoint.transform.position.x;
            this.y = checkpoint.transform.position.y;
            this.z = checkpoint.transform.position.z;
        }
    }

    public PlayerData(PlayerController player, GameObject checkpoint){
        this.level = player.level;
        this.health = player.currentHealth;
        this.damage = player.damage;
        this.position = new Vec3(checkpoint);
        this.sceneIndex = SceneManager.GetActiveScene().buildIndex;
        this.canAttack = player.canAttack;
        this.canArcLightning = player.canArcLightning;
        this.canThunder = player.canThunder;
    }
}