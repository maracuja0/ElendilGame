using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public GoblinEnemy enemy;
    public Text healthText;
    public Vector3 offset;

    void FixedUpdate()
    {
        healthText.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }
    void Update()
    {
        healthText.text = enemy.currentHealth.ToString();
    }
}
