using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause_menu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public Button restartButton;

    public Button pauseButton;

    public Slider slider;
    public GameObject loadingScreen;

    private void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameIsPaused){
            pauseButton.onClick.AddListener(Resume);
        }else{
            pauseButton.onClick.AddListener(Pause);
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadingScreenOnFade(1));
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
