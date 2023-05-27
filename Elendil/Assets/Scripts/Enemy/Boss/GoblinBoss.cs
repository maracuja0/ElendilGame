using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBoss : BaseEmeny
{
   public float attackDelay = 1f;
    public float needleAttackDelay = 3f;
    public float circleAttackDelay = 5f;
    public float attackTimer = 0f; 
    public Transform target; 
    private Animator anim;
    private Rigidbody2D rb;
    public GameObject gun;
    public Transform spawnPoint;
    public GameObject NeedlePrefab;
    public bool CircleAttackIsStarted = false;
    public DialogManager dialog3;
   new void Start()
    {
        base.Start();
        base.damage = 10;
        base.maxHealth = 250;
        base.currentHealth = maxHealth;
        base.moveSpeed = 10;
        base.spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        if(dialog3.DialogEnd){
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
            if (!CircleAttackIsStarted) {
                StartCoroutine(CircleAttackCoroutine());
                attackTimer = 0f;
            }
        }
        }
    }
    IEnumerator SupperAttackCoroutine(){
        EnemyBullet needleSkript = NeedlePrefab.GetComponent<EnemyBullet>();
        needleSkript.SetSpeed(20);
        needleSkript.damage = 15;
        for(int i = 0; i < 5; ++i){
            Vector2 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            gun.transform.rotation = Quaternion.Euler(0f, 0f, angle);
            GameObject bullet = Instantiate(NeedlePrefab, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(0.2f);
        }

        yield return new WaitForSeconds(1f);
        anim.SetBool("NeedleAttack", false);
    }
    IEnumerator AttackCoroutine(){
        anim.SetBool("NeedleAttack", true);
        yield return new WaitForSeconds(1f);
        EnemyBullet needleSkript = NeedlePrefab.GetComponent<EnemyBullet>();
        needleSkript.SetSpeed(15);
        needleSkript.damage = 10;
        GameObject bullet = Instantiate(NeedlePrefab, spawnPoint.position, spawnPoint.rotation);
        yield return new WaitForSeconds(1f);
        anim.SetBool("NeedleAttack", false);
    }

   IEnumerator NeedleAttackCoroutine(){
        anim.SetBool("NeedleAttack", true);
        yield return new WaitForSeconds(1f);
        Vector2 direction = (target.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        gun.transform.rotation = Quaternion.Euler(0f, 0f, angle);
        EnemyBullet needleSkript = NeedlePrefab.GetComponent<EnemyBullet>();
        needleSkript.SetSpeed(10);
        needleSkript.damage = 15;
        for(int i = 0; i < 24; ++i){
            gun.transform.rotation = Quaternion.Euler(0f, 0f, angle);
            GameObject needle = Instantiate(NeedlePrefab, spawnPoint.position, spawnPoint.rotation);
            angle += 15f;
        }
        yield return new WaitForSeconds(1f);
        anim.SetBool("NeedleAttack", false);
   }
   IEnumerator CircleAttackCoroutine(){
        CircleAttackIsStarted = true;
        anim.SetBool("ToCircle", true);
        yield return new WaitForSeconds(1f);
        StartCoroutine(base.MakeInvulnerable(5f));
        yield return new WaitForSeconds(5f);
        anim.SetBool("ToCircle", false);
        StartCoroutine(SupperAttackCoroutine());
        yield return new WaitForSeconds(3f);
        anim.SetBool("FromCircle", true);
        yield return new WaitForSeconds(1f);
        anim.SetBool("FromCircle", false);
        CircleAttackIsStarted = false;
   }
}
