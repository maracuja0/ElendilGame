using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public Transform firePoint;
    public Button shootButton;
    public GameObject bulletPrefab;
    private GameObject nearestEnemy;
    public AutoAim autoAim;

    void Start()
    {
        shootButton.onClick.AddListener(ShootSkill);
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
    }
    
    public void ShootSkill()
    {
        GameObject bullet = Instantiate(bulletPrefab, autoAim.firePoint.position, autoAim.firePoint.rotation);
    }
}
