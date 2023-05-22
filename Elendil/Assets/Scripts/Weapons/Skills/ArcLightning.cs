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
    public Animator anim;
    private bool canShoot = true;
    private float shootTime = 0f;
    public float reloadTime = 5f;
    public float range = 10f;

    void Start()
    {
        autoAim.range = range;
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

    IEnumerator Shooting(){
        anim.SetBool("IsAttack", true);
        yield return new WaitForSeconds(0.4f);
        LightningBullet lightningScript = lightningPrefab.GetComponent<LightningBullet>();
        lightningScript.SetTarget(nearestEnemy);

        if(nearestEnemy != null){
            GameObject lightning = Instantiate(lightningPrefab, autoAim.firePoint.position, autoAim.firePoint.rotation);
        }
        arcLightningButton.interactable = false;
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("IsAttack", false);
    }

    public void ArcLightningSkill()
    {
        if (canShoot && nearestEnemy != null){
            canShoot = false;
            StartCoroutine(Shooting());
        }   
    }
}