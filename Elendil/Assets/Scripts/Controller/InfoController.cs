using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InfoController : MonoBehaviour
{
    public Button button;

    // public void showInfo(){
    //     gameObject.SetActive(true);
    // }

    public void ButtonClick(){
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
