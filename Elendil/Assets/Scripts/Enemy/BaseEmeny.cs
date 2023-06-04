using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEmeny : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth = 0;
    public float moveSpeed = 2f;
    public int damage = 1;

    public SpriteRenderer spriteRenderer; // Ссылка на компонент SpriteRenderer врага
    public Color damageColor; // Цвет окрашивания при получении урона
    public float damageEffectDuration = 0.2f; // Длительность эффекта окрашивания при получении урона

    private Color originalColor = Color.white; // Исходный цвет спрайта врага

    public bool haveAdditionalObjects;
    public bool haveZelie;
    public GameObject additionalObject;
    public GameObject ZeliePrefab;
    
    public bool haveDialog = false;
    public GameObject rune;

    public DialogManager dialog4;

    public bool isInvulnerable = false;
    public int GetDamage(){
        return this.damage;
    }

    public int GetHealth(){
        return this.currentHealth;
    }

    public void SetDamage(int damage){
        this.damage = damage;
    }

    protected void Start()
    {
        currentHealth = maxHealth;
        damageColor = HexToColor("#FFCECE");
        // healthbar.maxValue = maxHealth;
    }

    private Color HexToColor(string hex)
    {
        Color color = Color.red; // Цвет по умолчанию, если процесс преобразования не удался

        if (ColorUtility.TryParseHtmlString(hex, out Color parsedColor))
        {
            color = parsedColor;
        }

        return color;
    }

     // Update is called once per frame
    protected void Update()
    {
        // healthbar.value = this.health;
        // healthbar.gameObject.SetActive(healthbar.value < maxHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!isInvulnerable){
            if (collision.tag == Tag.BULLET)
            {
                TakeDamage(collision.GetComponent<Bullet>().GetDamage());
            }else if(collision.tag == Tag.ARC_LIGHTNING)
            {
                TakeDamage(collision.GetComponent<LightningBullet>().GetDamage());
            }
        }
        
    }

    public void TakeDamage(int damage)
    {
        // this.OnAttacked(collider);
        if (currentHealth > damage)
        {
            spriteRenderer.color = damageColor;

            StartCoroutine(RestoreColorAfterDelay(damageEffectDuration));
            currentHealth -= damage;
        } else
        {
            currentHealth = 0;
            this.Die();
        }
    }

    private void Die() {
        Destroy(gameObject);
        if(haveAdditionalObjects){
            if(additionalObject != null){
                additionalObject.SetActive(true);
            }
            rune.SetActive(true);
        }
        if(haveZelie){
            GameObject HPZelie = Instantiate(ZeliePrefab, transform.position, transform.rotation);
        }
        if(haveDialog){
            dialog4.startDialog();
        }
    }
    private IEnumerator RestoreColorAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Восстанавливаем исходный цвет спрайта
        spriteRenderer.color = originalColor;
    }

    public IEnumerator MakeInvulnerable(float invulnerableTime)
    {
        isInvulnerable = true;
        yield return new WaitForSeconds(invulnerableTime);
        isInvulnerable = false;
    }
}
