using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBoss : BaseEmeny
{
   public float attackDelay = 1f;
    public float PrizyvDelay = 3f;
    public float attackTimer = 0f; 
    public Transform target; 
    private Animator anim;
    private Rigidbody2D rb;
    public GameObject gun;
    public Transform spawnPoint;
    public GameObject NeedlePrefab;
    public bool CircleAttackIsStarted = false;
    public DialogManager dialog3;
    public bool Spawn1Started = false;
    public bool Spawn2Started = false;

    public GameObject mobPrefab;  // Префаб моба, который вы хотите спавнить
    public BoxCollider2D spawnArea; // Ссылка на компонент Box Collider 2D
    private int spawnedCount;        // Количество спаунов в текущей волне

    public List<GameObject> Enemyes;
   new void Start()
    {
        base.Start();
        base.damage = 10;
        base.maxHealth = 450;
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
            Vector2 direction = (target.position - transform.position).normalized;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            gun.transform.rotation = Quaternion.Euler(0f, 0f, angle);

            attackTimer += Time.deltaTime;
            if(currentHealth >= 225){
                if (attackTimer >= attackDelay) {
                    StartCoroutine(AttackCoroutine()); 
                    attackTimer = 0f;
                }
            }else if(currentHealth >= 75 && currentHealth < 225){
                if(!Spawn1Started){
                    StartCoroutine(Priziv1Coroutine());
                }
                if (attackTimer >= attackDelay) {;
                    StartCoroutine(AttackCoroutine()); 
                    attackTimer = 0f;
                }
            }else{
                if(!Spawn2Started){
                    StartCoroutine(Priziv2Coroutine());
                }
                if (attackTimer >= attackDelay) {
                    StartCoroutine(AttackCoroutine()); 
                    attackTimer = 0f;
                }
            }
        }
    }
    IEnumerator AttackCoroutine(){
        anim.SetBool("ToAttack", true);
        yield return new WaitForSeconds(1f);
        EnemyBullet needleSkript = NeedlePrefab.GetComponent<EnemyBullet>();
        needleSkript.SetSpeed(20);
        needleSkript.damage = 15;
        GameObject bullet = Instantiate(NeedlePrefab, spawnPoint.position, spawnPoint.rotation);
        yield return new WaitForSeconds(1f);
        anim.SetBool("ToAttack", false);
    }

    IEnumerator Priziv1Coroutine(){
        anim.SetBool("ToPriziv", true);
        Spawn1Started = true;
        yield return new WaitForSeconds(1f);

        for(int i = 0; i < 2; ++i){
            Vector2 spawnPoint = GetRandomSpawnPoint();
            GameObject mob = Instantiate(mobPrefab, spawnPoint, Quaternion.identity);
            spawnedCount++;
            Enemyes.Add(mob);
            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(1f);
        anim.SetBool("ToPriziv", false);
    }

    IEnumerator Priziv2Coroutine(){
        anim.SetBool("ToPriziv", true);
        Spawn2Started = true;
        yield return new WaitForSeconds(1f);

        for(int i = 0; i < 3; ++i){
            Vector2 spawnPoint = GetRandomSpawnPoint();
            GameObject mob = Instantiate(mobPrefab, spawnPoint, Quaternion.identity);
            spawnedCount++;
            Enemyes.Add(mob);
            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(1f);
        anim.SetBool("ToPriziv", false);
    }

    private Vector2 GetRandomSpawnPoint()
    {
        Vector2 size = spawnArea.bounds.size;
        Vector2 center = spawnArea.bounds.center;
        float randomX = Random.Range(-size.x / 2f, size.x / 2f);
        float randomY = Random.Range(-size.y / 2f, size.y / 2f);
        return new Vector2(center.x + randomX, center.y + randomY);
    }
}
