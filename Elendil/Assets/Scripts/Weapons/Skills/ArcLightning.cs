using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArcLightning : MonoBehaviour
{
    public Button arcLightningButton;
    public GameObject lightningPrefab;
    public GameObject nearestEnemy;
    public AutoAim autoAim;
    private bool canShoot = true;
    private float shootTime = 0f;
    public float reloadTime = 5f;

    void Start()
    {
        arcLightningButton.onClick.AddListener(ArcLightningSkill);
    }
    void Update()
    {
        nearestEnemy = autoAim.nearestEnemy;

        if (nearestEnemy != null)
        {
            // Направляем оружие на ближайшего врага
            Vector2 direction = nearestEnemy.transform.position - transform.position;
            transform.up = direction;
        }

        if (!canShoot)
        {
            // Отсчитываем время до возможности следующего выстрела
            shootTime += Time.deltaTime;

            if (shootTime > reloadTime)
            {
                canShoot = true;
                arcLightningButton.interactable = true;
                shootTime = 0f;
            }
        }
    }

    public void ArcLightningSkill()
    {
        if (canShoot)
        {
            LightningBullet lightningScript = lightningPrefab.GetComponent<LightningBullet>();
            lightningScript.SetTarget(nearestEnemy);

            if(nearestEnemy != null){
                GameObject lightning = Instantiate(lightningPrefab, autoAim.firePoint.position, autoAim.firePoint.rotation);
            }
            canShoot = false;
            arcLightningButton.interactable = false;
        }
        
    }
}