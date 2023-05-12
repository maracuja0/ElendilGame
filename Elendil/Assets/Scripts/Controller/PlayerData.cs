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
    
    [System.Serializable]
    public struct Vec3{
        public float x, y, z;

        public Vec3(Checkpoints checkpoint){
            GameObject cp = checkpoint.GetCurrentCheckpoint();
            this.x = cp.transform.position.x;
            this.y = cp.transform.position.y;
            this.z = cp.transform.position.z;
        }
    }

    public PlayerData(PlayerController player, Checkpoints checkpoint){
        this.level = player.level;
        this.health = player.currentHealth;
        this.damage = player.damage;
        this.position = new Vec3(checkpoint);
        this.sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
}