using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameButtonsController : MonoBehaviour
{
    public Button attackButton;

    public GameObject arcLightningButton;
    public PlayerController player;
    public void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public void setActiveAttack(){
        attackButton.interactable = true;
    }

    public void setDeActiveAttack(){
        attackButton.interactable = false;
    }

    public void setActiveArcLightning(){
        player.canArcLightning = true;
        arcLightningButton.SetActive(true);
    }   

    public void setDeActiveArcLightning(){
        player.canArcLightning = false;
        arcLightningButton.SetActive(false);
    }  
}
