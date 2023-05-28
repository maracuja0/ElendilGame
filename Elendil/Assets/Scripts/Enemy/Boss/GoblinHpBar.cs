using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoblinHpBar : MonoBehaviour
{
    public Slider hp;
    public GoblinBoss boss;
    public Image slaiderImage;

    void Start()
    {
        boss = FindObjectOfType<GoblinBoss>();
        
    }
    // Update is called once per frame
    void Update()
    {
        hp.maxValue = boss.maxHealth;
        hp.minValue = 0;
        hp.value = boss.currentHealth;
        if(hp.value >= 225){
            slaiderImage.color = Color.green;
        }else if(hp.value >= 75 && hp.value < 225){
            slaiderImage.color = Color.yellow;
        }else if(hp.value < 75){
            slaiderImage.color = Color.red;
        }
    }
}
