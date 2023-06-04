using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;

    void Start()
    {
        StartCoroutine(showLoadPicture());
    }

    IEnumerator showLoadPicture(){
        yield return new WaitForSeconds(2f);
        StartCoroutine(LoadingScreenOnFade(SceneManager.GetActiveScene().buildIndex + 1));
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
