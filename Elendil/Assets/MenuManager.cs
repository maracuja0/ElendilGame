using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour{
    public void ChangeSceneName(string name) {

        SceneManager.LoadScene(name);
    }
}
