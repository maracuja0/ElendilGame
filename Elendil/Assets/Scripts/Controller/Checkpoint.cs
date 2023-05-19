using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Checkpoints checkpoints;
    public bool cheacked = false;
    private SaveManager saveManager;
    private PlayerController player;
    private const string key = "mainSave";

    public void Awake()
    {
        saveManager = FindObjectOfType<SaveManager>(); // Найти объект SaveManager в сцене
        player = FindObjectOfType<PlayerController>();
    }

    public Vector3 GetCheckpointPosition(){
        return transform.position;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == Tag.PLAYER){
            if(!cheacked){
                cheacked = true;
                saveManager.SaveGame(key, new PlayerData(player, gameObject));
            }
        }    
    }
}
