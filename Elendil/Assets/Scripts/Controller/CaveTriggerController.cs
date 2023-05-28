using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveTriggerController : MonoBehaviour
{
    public GameObject objectToActive;
    public List<GameObject> Enemyes;
    public int countOfEnemyes;
    void Update()
    {
        for(int i = 0; i < Enemyes.Count; ++i){
            if(Enemyes[i] == null){
                countOfEnemyes--;
                Enemyes.RemoveAt(i);
            }
        }

        if(countOfEnemyes == 0){
            objectToActive.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == Tag.PLAYER){
            objectToActive.SetActive(true);
        }
    }
}
