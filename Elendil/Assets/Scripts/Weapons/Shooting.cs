using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed;

    public Transform spawnPoint;

    // public GameObject[] enemyes = new GameObject[3];
    public List<GameObject> Enemyes = new List<GameObject>();

    private GameObject target;

    public GameObject EnemyPrefab;

    public GameObject gun;  

   void Update()
    {
        autoAim();
        if(target == null){
            return;
        }else{
            Vector3 Aim = (target.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(Aim.y, Aim.x) * Mathf.Rad2Deg - 90f;
            gun.transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
            
    }
    
    public void FireBullet(){
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, gun.transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.velocity = bulletSpeed * spawnPoint.up;
    }
     void autoAim(){
        if(Enemyes.Count == 0){
            return;
        }else{
            target = GameObject.FindGameObjectWithTag("Enemy") ? GameObject.FindGameObjectWithTag("Enemy") : null;
            foreach(var i in Enemyes ){
                if(i == null){
                    Enemyes.Remove(i);
                    break;
                }else if(Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(i.transform.position.x, i.transform.position.y)) <
                Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(target.transform.position.x, target.transform.position.y))){
                    target = i; 
                }
            }
        }
        
    }

    // void autoAim(){
    //     target = GameObject.FindWithTag("Enemy");
    //     GameObject findTarget = GameObject.FindWithTag("Enemy");
    //     if(Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(findTarget.transform.position.x, findTarget.transform.position.y)) <
    //         Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(target.transform.position.x, target.transform.position.y))){
    //         target = findTarget; 
    //     }
    // }
}
