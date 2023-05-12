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
    }

    public void LoadGame(){
        if (File.Exists(saveFilePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = new FileStream(saveFilePath, FileMode.Open);
            saveData = (PlayerData)bf.Deserialize(file);
            file.Close();
            SceneManager.LoadScene(saveData.sceneIndex);
        }
        
    }

    public void NewGame(){
        if (File.Exists(saveFilePath))
        {
            File.Delete(saveFilePath);
            Debug.Log("File deleted successfully.");
        }else{
            Debug.LogWarning("File not found.");
        }
        SceneManager.LoadScene(1);
    }

    public void QuiteGame(){
        Application.Quit();
    }
}
