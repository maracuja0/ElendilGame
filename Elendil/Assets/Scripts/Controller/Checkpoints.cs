using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    public GameObject currentCheckpoint;

    public void SetCurrentCheckpoint(GameObject checkpoint){
        this.currentCheckpoint = checkpoint;
    }

    public GameObject GetCurrentCheckpoint(){
        return currentCheckpoint;
    }
}
