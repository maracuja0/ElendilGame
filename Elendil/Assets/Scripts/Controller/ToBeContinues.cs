using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToBeContinues : MonoBehaviour
{
    public GameObject ToBeContinued;

    public Slider slider;
    public GameObject loadingScreen;


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == Tag.PLAYER){
            StartCoroutine(Continue());
        }
    }

    IEnumerator Continue(){
        yield return new WaitForSeconds(1f);
        ToBeContinued.SetActive(true);
    }

    public void LoadMenu()
    {
        StartCoroutine(LoadingScreenOnFade(1));
    }

    IEnumerator LoadingScreenOnFade(int index){
        yield return new WaitForSeconds(1f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        loadingScreen.SetActive(true);
        while(!operation.isDone){
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
}
