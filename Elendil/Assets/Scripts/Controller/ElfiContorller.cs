using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElfiContorller : MonoBehaviour
{
    public PlayerController target;
    public float distanceRadius = 5f;
    public Rigidbody2D rb;
    public float moveSpeed = 3;
    public DialogManager dialog;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dialog.DialogEnd){
            float distance = Vector2.Distance(transform.position, target.transform.position);

            Vector2 direction = (target.transform.position - transform.position).normalized;

            // Поворот в направлении игрока
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            //gun.transform.rotation = Quaternion.Euler(0f, 0f, angle);

            if (distance > distanceRadius)
            {
                rb.velocity = direction * moveSpeed;
                anim.SetFloat("X", direction.x);
                anim.SetFloat("Y", direction.y);
                anim.SetFloat("Speed", 0.2f);
            }
            else
            {
                rb.velocity = Vector2.zero;
                anim.SetFloat("X", 0);
                anim.SetFloat("Y", 0);
                anim.SetFloat("Speed", 0);
            }
        }
    }
}
