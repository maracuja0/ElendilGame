using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.Android;

//Нужно сохранять здоровье врага, урон его скиллов
//Сохранение делать по позиции триггера на сохранение(то есть он должен появиться ровно на месте триггера)

public class SaveManager : MonoBehaviour
{
    private PlayerData saveData;
    public PlayerController player;
    public Checkpoints checkpoint;
    public GameObject spawnPoint;
    private string saveFilePath;
    public GameObject savedGameText;

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
        saveFilePath = Path.Combine(Application.persistentDataPath, "savefile.dat");
        if (File.Exists(saveFilePath))
        {
            LoadGame();
        }
    }
    public void LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = new FileStream(saveFilePath, FileMode.Open);
            saveData = (PlayerData)bf.Deserialize(file);
            player.LoadData(saveData);
            file.Close();
        }
    }
    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = new FileStream(saveFilePath, FileMode.Create);
        saveData = new PlayerData(player, checkpoint);
        bf.Serialize(file, saveData);
        Debug.Log("Game Saved!");
        file.Close();
        StartCoroutine(savedGameTextShow());
    }

     IEnumerator savedGameTextShow(){
        savedGameText.SetActive(true);
        yield return new WaitForSeconds(3f);
        savedGameText.SetActive(false);
    }
}

