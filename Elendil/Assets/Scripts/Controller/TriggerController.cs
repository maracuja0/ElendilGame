using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    public bool is_cheaked = false;
    public GameObject objectToActive;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(!is_cheaked && other.tag == Tag.PLAYER){
            is_cheaked = true;
            objectToActive.SetActive(true);
        }
    }
}
