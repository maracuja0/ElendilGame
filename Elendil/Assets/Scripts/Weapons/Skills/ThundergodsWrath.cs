using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThundergodsWrath : MonoBehaviour
{
    public Button thundergodsWrathButton;
    public float radius = 10f;
    public int damage = 10;
    private bool canShoot = true;
    private float shootTime = 0f;
    public float reloadTime = 10f;

    void Start()
    {
        thundergodsWrathButton.onClick.AddListener(ThundergodsWrathSkill);
    }

    // Update is called once per frame
    void Update()
    {
        if (!canShoot)
        {
            // Отсчитываем время до возможности следующего выстрела
            shootTime += Time.deltaTime;

            if (shootTime > reloadTime)
            {
                canShoot = true;
                thundergodsWrathButton.interactable = true;
                shootTime = 0f;
            }
        }
    }

    public void ThundergodsWrathSkill(){
        if (canShoot)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject.CompareTag(Tag.ENEMY))
                {
                    collider.gameObject.GetComponent<BaseEmeny>().TakeDamage(damage);
                }
            }
            canShoot = false;
            thundergodsWrathButton.interactable = false;
        }
        
    }
}
