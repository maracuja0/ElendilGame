using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageDisplay : MonoBehaviour
{
    public GameObject message;
    public bool is_trigger = false;
    public Vector3 offset;

    void Start()
    {
        
    }

    void Update()
    {
        message.transform.position = Camera.main.WorldToScreenPoint(transform.position + offset);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == Tag.PLAYER){
            is_trigger = true;
            message.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == Tag.PLAYER){
            is_trigger = false;
            message.SetActive(false);
        }
    }
}
