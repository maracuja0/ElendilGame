using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{ 
    void OnCollisionEnter2D(Collision2D other)
    {
        //Тут должна быть ваша обработка попадания
        //Вместо этого условия необходимо ваше, которое определит, что
        //в Collision находится именно тот объект, который вам нужен
        if (other==null)
        {
           Destroy(gameObject);
            
        }
    }
}
