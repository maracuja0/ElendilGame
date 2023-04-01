using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAim : MonoBehaviour
{
    public Transform firePoint;
    public float range = 10f;
    public GameObject nearestEnemy;
    
    void Update()
    {
        // Находим ближайшего врага
        nearestEnemy = FindNearestEnemy();

        if (nearestEnemy != null)
        {
            // Направляем оружие на ближайшего врага
            Vector2 direction = nearestEnemy.transform.position - transform.position;
            transform.up = direction;
        }
    }
   
    public GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(Tag.ENEMY);
        GameObject nearestEnemy = null;
        float nearestEnemyDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < nearestEnemyDistance)
            {
                nearestEnemy = enemy;
                nearestEnemyDistance = distance;
            }
        }

        return nearestEnemy;
    }
}

