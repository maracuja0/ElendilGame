using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_bar : MonoBehaviour
{
    public Image healthBar;
    public PlayerController player;

    void Start()
    {
        healthBar = GetComponent<Image>();
        player = FindObjectOfType<PlayerController>();
    }

    
    void Update()
    {
        healthBar.fillAmount = player.currentHealth / player.maxHealth;
    }
}
