using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EzzzhikBoss : BaseEmeny
{
    public float attackDelay = 1f;
    public float needleAttackDelay = 3f;
    public float attackTimer = 0f; 
    public Transform target; 
    private Animator anim;
    private Rigidbody2D rb;
    public GameObject gun;
    public Transform spawnPoint;
    public GameObject NeedlePrefab;
   new void Start()
    {
        base.Start();
        base.damage = 10;
        base.maxHealth = 250;
        base.currentHealth = maxHealth;
        base.moveSpeed = 10;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        if(currentHealth >= 175){
            Vector2 direction = (target.position - transform.position).normalized;
    
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            gun.transform.rotation = Quaternion.Euler(0f, 0f, angle);

            attackTimer += Time.deltaTime;
            if (attackTimer >= attackDelay) {
                // Attack();
                StartCoroutine(AttackCoroutine()); 
                attackTimer = 0f;
            }
        }else if(currentHealth >= 75 && currentHealth < 175){
            attackTimer += Time.deltaTime;
            if (attackTimer >= needleAttackDelay) {
                StartCoroutine(NeedleAttackCoroutine());   
                attackTimer = 0f;
            }
        }else if(currentHealth < 75){
            attackTimer += Time.deltaTime;
            if (attackTimer >= needleAttackDelay) {
                StartCoroutine(CircleAttackCoroutine());
                attackTimer = 0f;
            }
        }
    }

    private void Attack(){
        EnemyBullet needleSkript = NeedlePrefab.GetComponent<EnemyBullet>();
        needleSkript.SetDamage(damage);
        needleSkript.SetSpeed(15);
        GameObject bullet = Instantiate(NeedlePrefab, spawnPoint.position, spawnPoint.rotation);
    }
    IEnumerator AttackCoroutine(){
        anim.SetBool("NeedleAttack", true);
        yield return new WaitForSeconds(1f);
        EnemyBullet needleSkript = NeedlePrefab.GetComponent<EnemyBullet>();
        needleSkript.SetDamage(damage);
        needleSkript.SetSpeed(15);
        GameObject bullet = Instantiate(NeedlePrefab, spawnPoint.position, spawnPoint.rotation);
        yield return new WaitForSeconds(1f);
        anim.SetBool("NeedleAttack", false);
    }

   IEnumerator NeedleAttackCoroutine(){
        anim.SetBool("NeedleAttack", true);
        yield return new WaitForSeconds(1f);
        float angle = 0;
        gun.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        for(int i = 0; i < 24; ++i){
            EnemyBullet needleSkript = NeedlePrefab.GetComponent<EnemyBullet>();
            needleSkript.SetDamage(15);
            needleSkript.SetSpeed(5);
            gun.transform.rotation = Quaternion.Euler(0f, 0f, angle);
            GameObject needle = Instantiate(NeedlePrefab, spawnPoint.position, spawnPoint.rotation);
            angle += 15f;
        }
        yield return new WaitForSeconds(1f);
        anim.SetBool("NeedleAttack", false);
   }
   IEnumerator CircleAttackCoroutine(){
        anim.SetBool("ToCircle", true);
        yield return new WaitForSeconds(1f);
        base.MakeInvulnerable(5f);
        Transform currenPos = gameObject.transform;
        yield return new WaitForSeconds(1f);
        anim.SetBool("ToCircle", false);
        yield return new WaitForSeconds(1f);
        anim.SetBool("FromCircle", true);
        // anim.SetBool("Circle", true);
        // Transform targetPos = target.transform;
        // Vector2 direction = (targetPos.position - gameObject.transform.position).normalized;
        // while(gameObject.transform.position != targetPos.position){
        //     rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
        // }
   }
}
