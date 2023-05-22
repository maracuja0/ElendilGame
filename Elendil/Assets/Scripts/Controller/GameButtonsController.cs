using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameButtonsController : MonoBehaviour
{
    public Button attackButton;

    public void Start()
    {

    }

    public void setActiveAttack(){
        attackButton.interactable = true;
    }

    public void setDeActiveAttack(){
        attackButton.interactable = false;
    }
}
