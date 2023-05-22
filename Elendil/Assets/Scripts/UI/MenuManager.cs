using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.Android;

public class MenuManager : MonoBehaviour
{
    private PlayerData saveData;
    public GameObject player;
    public string saveFilePath;
    public bool is_continue = true;
    private const string key = "mainSave";
    public GameObject continueButton;

    public Slider slider;
    public GameObject loadingScreen;

    private void RequestStoragePermissions()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageRead))
        {
            Permission.RequestUserPermission(Permission.ExternalStorageRead);
        }

        if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
        {
            Permission.RequestUserPermission(Permission.ExternalStorageWrite);
        }
    }

    void Start()
    {
        RequestStoragePermissions();
        if(PlayerPrefs.HasKey(key)){
            continueButton.SetActive(true);
        }
    }

    public void LoadGame(){
        if(PlayerPrefs.HasKey(key)){
            PlayerData saveData;
            string loadedString = PlayerPrefs.GetString(key);
            saveData = JsonUtility.FromJson<PlayerData>(loadedString);
            StartCoroutine(LoadingScreenOnFade(saveData.sceneIndex));
        }
    }

    public void NewGame(){
        if(PlayerPrefs.HasKey(key)){
            PlayerPrefs.DeleteAll();
        }
        StartCoroutine(LoadingScreenOnFade(1));
    }

    public void QuiteGame(){
        Application.Quit();
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
