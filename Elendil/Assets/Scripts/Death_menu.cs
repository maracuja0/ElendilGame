using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Death_menu : MonoBehaviour
{
    public bool GameIsPaused = false;
    public GameObject deathMenuUI;
    public Button restartButton;
    public Button menuButton;
    
    public Slider slider;
    public GameObject loadingScreen;

    void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
        menuButton.onClick.AddListener(LoadMenu);
    }
    
    public void Death(){
        deathMenuUI.SetActive(true);
        GameIsPaused = true;
        Time.timeScale = 0f;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadingScreenOnFade(0));
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadingScreenOnFade(SceneManager.GetActiveScene().buildIndex));
        GameIsPaused = false;
    }
    IEnumerator LoadingScreenOnFade(int index){
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        loadingScreen.SetActive(true);
        while(!operation.isDone){
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
}
