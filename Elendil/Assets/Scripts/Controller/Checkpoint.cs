using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Checkpoints checkpoints;
    public bool cheacked = false;
    public SaveManager saveManager;
    public Vector3 GetCheckpointPosition(){
        return transform.position;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == Tag.PLAYER){
            if(!cheacked){
                cheacked = true;
                checkpoints.SetCurrentCheckpoint(gameObject);
                saveManager.SaveGame();
            }
            
        }    
    }
}
