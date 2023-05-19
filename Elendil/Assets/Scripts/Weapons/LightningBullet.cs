using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBullet : MonoBehaviour
{
    private int damage = 5;
    public float speed = 2f;
    public int maxBounces = 3;
    private float bounceRange = 15f;
    public int currentBounces = 0 ;
    public GameObject nextTarget;
    public GameObject target;
    public Vector3 direction;
    public Vector2 rotation;
    public Animator anim;
    public Rigidbody2D rb;
    private List<GameObject> hitTargets = new List<GameObject>();
    
    public void SetTarget(GameObject currentTarget){
        this.target = currentTarget;
    }

    void Start()
    {
        if (target != null){
            direction = (target.transform.position - transform.position).normalized;
        }
    }
    
    void Update()
    {
        if (target != null){
            direction = (target.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
            rotation = target.transform.position - transform.position;
            transform.up = rotation;
        }else{
            Destroy(gameObject);
        }
        
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tag.ENEMY))
        {
            currentBounces++;
            if (currentBounces > maxBounces)
            {
                Destroy(gameObject);
            }
            else
            {
                hitTargets.Add(target);
                target = FindNextTarget(target);
                if (target == null)
                {
                    Destroy(gameObject);
                }
                else if (Vector2.Distance(transform.position, target.transform.position) > bounceRange)
                {
                    Destroy(gameObject);
                }
            }
    }
    else if (collision.gameObject.CompareTag(Tag.WALL))
    {
        Destroy(gameObject);
    }
    }

    private GameObject FindNextTarget(GameObject currentTarget)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(Tag.ENEMY);
        GameObject nextTarget = null;
        float nearestEnemyDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < nearestEnemyDistance && distance < bounceRange && !hitTargets.Contains(enemy) && enemy != currentTarget)
            {
                nextTarget = enemy;
                nearestEnemyDistance = distance;
            }
        }

        return nextTarget;
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }
    public int GetDamage()
    {
        return this.damage;
    }
}
