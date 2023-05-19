using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneController : MonoBehaviour
{
    public GameObject info;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == Tag.PLAYER){
            info.SetActive(true);
            Destroy(gameObject);
            Time.timeScale = 0f;
        }
    }
}
