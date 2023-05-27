using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    public bool many_objects = false;
    public bool is_cheaked = false;
    public GameObject objectToActive;
    public GameObject[] objectsToActive;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(!is_cheaked && other.tag == Tag.PLAYER){
            is_cheaked = true;
            if(many_objects){
                foreach(GameObject Object in objectsToActive){
                    Object.SetActive(true);
                }
            }else{
                objectToActive.SetActive(true);
            }
        }
    }
}
