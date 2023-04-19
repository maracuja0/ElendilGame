using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//Нужно сохранять здоровье врага, урон его скиллов
//Сохранение делать по позиции триггера на сохранение(то есть он должен появиться ровно на месте триггера)

public class SaveManager : MonoBehaviour
{
    private PlayerData saveData;
    public PlayerController player;
    public Checkpoints checkpoint;
    private string saveFilePath;

    void Start()
    {
        saveFilePath = Application.persistentDataPath + "/savedata.dat";
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
    }

}

