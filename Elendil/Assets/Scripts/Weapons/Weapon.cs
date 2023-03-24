using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject lightningPrefab;
    public float range = 10f;
    public int damage = 10;


    // public float lightningRadius = 10f;
    // public float lightningRange = 2f;
    // public int maxBounces = 3;
    // private float nextFireTime = 5f;

    // private float nextFireTime = 0f;
    public GameObject nearestEnemy;
    public GameObject NearestEnemy{
        get
        {
            return this.nearestEnemy;
        }
    }
    
    void Update()
    {
        // Находим ближайшего врага
        nearestEnemy = FindNearestEnemy();

        if (nearestEnemy != null)
        {
            // Направляем оружие на ближайшего врага
            Vector2 direction = nearestEnemy.transform.position - transform.position;
            transform.up = direction;

            // Стреляем, если нажата кнопка выстрела и прошло достаточно времени с предыдущего выстрела
            // if (fireButtonCanvas.enabled && Time.time >= nextFireTime)
            // {
            //     Shoot();
            //     nextFireTime = Time.time + fireRate;
            // }
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

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    public void ArcLightning()
    {
        LightningBullet lightningScript = lightningPrefab.GetComponent<LightningBullet>();
        lightningScript.SetTarget(nearestEnemy);
        if(nearestEnemy != null){
            GameObject lightning = Instantiate(lightningPrefab, firePoint.position, firePoint.rotation);
        }
        
    }



    // public void LightningSkill(){
    //     GameObject lightning = Instantiate(lightningPrefab, firePoint.position, firePoint.rotation);
    //     int currentBounces = 0; 
    //     while(currentBounces < maxBounces){
    //         if (){

    //         }
    //     }
    // }
}

