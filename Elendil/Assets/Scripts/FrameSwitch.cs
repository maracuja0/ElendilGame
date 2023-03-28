using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameSwitch : MonoBehaviour
{
    public GameObject activeFrame;
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(Tag.PLAYER)){
            activeFrame.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag(Tag.PLAYER)){
            activeFrame.SetActive(false);
        }
    }
}
