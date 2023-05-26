using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public bool is_cheaked = false;
    private SaveManager saveManager;
    private PlayerController player;
    public GameObject spawnPoint;
    private const string key = "mainSave";


    void Start()
    {
        saveManager = FindObjectOfType<SaveManager>(); // Найти объект SaveManager в сцене
        player = FindObjectOfType<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(!is_cheaked && other.tag == Tag.PLAYER){
            StartCoroutine(LoadingScreenOnFade(SceneManager.GetActiveScene().buildIndex + 1));
            saveManager.SaveGame(key, new PlayerData(player, spawnPoint));
        }
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
