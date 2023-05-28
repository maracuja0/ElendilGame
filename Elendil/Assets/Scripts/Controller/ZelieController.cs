using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZelieController : MonoBehaviour
{
    public PlayerController player;
    public int HP;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == Tag.PLAYER){
            if(player.currentHealth < player.maxHealth - HP){
                player.currentHealth += HP;
            }else{
                player.currentHealth = player.maxHealth;
            }
            Destroy(gameObject);
        }
    }
}
