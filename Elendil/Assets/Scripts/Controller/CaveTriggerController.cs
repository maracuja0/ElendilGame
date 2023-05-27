using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveTriggerController : MonoBehaviour
{
    public GameObject objectToActive;
    public GameObject[] Enemyes;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == Tag.PLAYER){
            
        }
    }
}
