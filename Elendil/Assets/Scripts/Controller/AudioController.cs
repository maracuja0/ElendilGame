using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource mainSource;
    public AudioSource audioSource;
    
    public bool is_cheaked = false;


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == Tag.PLAYER){
            if(!is_cheaked){
                mainSource.Stop();  
                audioSource.Play();
                is_cheaked = true;
            }
        }
    }
}
