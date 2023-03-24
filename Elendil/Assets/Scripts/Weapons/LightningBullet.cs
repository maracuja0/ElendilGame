using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBullet : MonoBehaviour
{
    private float damage = 5f;
    public float speed = 2f;
    public int maxBounces = 3;
    private float bounceRange = 10f;
    public int currentBounces = 0 ;
    public GameObject nextTarget;
    public GameObject target;
    public Vector3 direction;
    public Vector2 rotation;
    public Rigidbody2D rb;
    private List<GameObject> hitTargets = new List<GameObject>();
    
    void Start()
    {
        direction = (target.transform.position - transform.position).normalized;
    }
    public void SetTarget(GameObject currentTarget){
        this.target = currentTarget;
    }
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        rotation = target.transform.position - transform.position;
        transform.up = rotation;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            currentBounces++;
            if (currentBounces > maxBounces)
            {
                Destroy(gameObject);
            }else if(FindNextTarget(target) == null)
            {
                Destroy(gameObject);
            }
            else
            {
                hitTargets.Add(target);
                target = FindNextTarget(target);
                direction = (target.transform.position - transform.position).normalized;
            }
        }
    }

    GameObject FindNextTarget(GameObject currentTarget)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(Tag.ENEMY);
        GameObject nextTarget = null;
        float nearestEnemyDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            if (enemy == currentTarget || hitTargets.Contains(enemy) || (Vector2.Distance(transform.position, enemy.transform.position) > bounceRange))
            {
                continue;
            }

            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < nearestEnemyDistance)
            {
                nextTarget = enemy;
                nearestEnemyDistance = distance;
            }
        }

        return nextTarget;
    }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }
    public float GetDamage()
    {
        return this.damage;
    }
}
