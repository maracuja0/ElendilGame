using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite treeBezPosoha;
    public bool is_cheaked = false;
    public PlayerController player;

    public GameButtonsController buttonsController;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        buttonsController = FindObjectOfType<GameButtonsController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(!is_cheaked){
            spriteRenderer.sprite = treeBezPosoha;
            is_cheaked = true;
            if(!player.canAttack){
                player.canAttack = true;
                buttonsController.setActiveAttack();
            }
        }
    }
}
