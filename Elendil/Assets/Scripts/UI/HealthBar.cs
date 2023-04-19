using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerController player;
    private Slider healhtbarSlider;

    void Start()
    {
        healhtbarSlider = GetComponent<Slider>();
    }

    public void UpdateHealthBar(int maxHealth, float currentHealth)
    {
        healhtbarSlider.maxValue = maxHealth;
        healhtbarSlider.minValue = 0;
        healhtbarSlider.value = currentHealth;
    }
}
