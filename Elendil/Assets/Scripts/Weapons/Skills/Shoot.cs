using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class Shoot : MonoBehaviour
{
    public Transform firePoint;
    public Button shootButton;
    public GameObject bulletPrefab;
    private GameObject nearestEnemy;
    public AutoAim autoAim;
    public Animator anim;
    public bool is_shooting = false;
    public float range = 20f;

    void Start()
    {
        autoAim.range = range;
        shootButton.onClick.AddListener(ShootSkill);
        //anim = GetComponent<Animator>();
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
    
    IEnumerator Shooting(){
        is_shooting = true;
        shootButton.interactable = false;
        anim.SetBool("IsAttack", true);
        yield return new WaitForSeconds(0.4f);
        GameObject bullet = Instantiate(bulletPrefab, autoAim.firePoint.position, autoAim.firePoint.rotation);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("IsAttack", false);
        is_shooting = false;
        shootButton.interactable = true;
    }
    public void ShootSkill()
    {
        if(!is_shooting)
            StartCoroutine(Shooting());
    }
}
