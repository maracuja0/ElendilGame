using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    
    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    // void OnTriggerEnter2D(Collider2D hitInfo)
    // {
    //     // Уничтожаем пулю при столкновении с другим объектом
    //     Destroy(gameObject);

    //     // Добавляем код обработки столкновения пули с другими объектами
    //     // ...
    // }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Tag.ENEMY)
        {
            Destroy(gameObject);
        }else{
            Destroy(gameObject, 2f);
        }
    }

}
