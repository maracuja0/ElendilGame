using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.Android;

public class SaveManager : MonoBehaviour
{
    public GameObject savedGameText;
    private PlayerController player;
    private const string key = "mainSave";

    public void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public void LoadGame(string key)
    {
        PlayerData saveData;
        if(PlayerPrefs.HasKey(key)){
            string loadedString = PlayerPrefs.GetString(key);
            saveData = JsonUtility.FromJson<PlayerData>(loadedString);
            player.LoadData(saveData);
        }

    }
    public void SaveGame(string key, PlayerData saveData)
    {
        string jsonDataString = JsonUtility.ToJson(saveData, true);
        PlayerPrefs.SetString(key, jsonDataString);
        PlayerPrefs.Save();
        StartCoroutine(savedGameTextShow());
    }

     IEnumerator savedGameTextShow(){
        savedGameText.SetActive(true);
        yield return new WaitForSeconds(3f);
        savedGameText.SetActive(false);
    }
}

