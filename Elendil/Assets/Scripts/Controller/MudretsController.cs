using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudretsController : MonoBehaviour
{
    public DialogManager dialog;
    public GameObject portal;
    public bool is_cheacked = false;

    void Update()
    {
        if(dialog.DialogEnd){
            if(!is_cheacked){
                portal.SetActive(true);
            }
        }
        
    }
}
