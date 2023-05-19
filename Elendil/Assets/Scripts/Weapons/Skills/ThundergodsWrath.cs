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
    public Animator anim;

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

    IEnumerator Shooting(){
        anim.SetBool("IsAttack", true);
        yield return new WaitForSeconds(0.4f);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.CompareTag(Tag.ENEMY))
            {
                collider.gameObject.GetComponent<BaseEmeny>().TakeDamage(damage);
                Debug.Log("Ulteded");
            }
        }
        thundergodsWrathButton.interactable = false;
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("IsAttack", false);
    }

    public void ThundergodsWrathSkill(){
        if (canShoot){
            canShoot = false;
            StartCoroutine(Shooting());
        }    
    }
}
