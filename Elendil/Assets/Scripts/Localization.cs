using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Localization : MonoBehaviour
{
    Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>{
        {"continue_button", new List<string> {"Продолжить", "Continue", "Continuar"}},
        {"start_button", new List<string> {"Новая игра", "New Game", "Partida nueva"}},
        {"quit_button", new List<string> {"Выход", "Quit", "Salir"}}
    };
    public Button localization;
    public Button Russian;
    public Button English;
    public Button Spanish;

    public Text continueButtonText;
    public Text startButtonText;
    public Text quitButtonText;

    public Text mainButtonText;

    public bool is_open = false;
    public GameObject languages;
    public void ShowHideLanguages(){
        if(!is_open){
            is_open = true;
            languages.SetActive(true);
        }else{
            is_open = false;
            languages.SetActive(false);
        }
    }

    public void SwitchToRussian(){
        continueButtonText.text = dict["continue_button"][0];
        startButtonText.text = dict["start_button"][0];
        quitButtonText.text = dict["quit_button"][0];
        mainButtonText.text = "RU";
        is_open = false;
        languages.SetActive(false);
    }

    public void swithToEnglish(){
        continueButtonText.text = dict["continue_button"][1];
        startButtonText.text = dict["start_button"][1];
        quitButtonText.text = dict["quit_button"][1];
        mainButtonText.text = "EN";
        is_open = false;
        languages.SetActive(false);
    }

    public void swithToSpanish(){
        continueButtonText.text = dict["continue_button"][2];
        startButtonText.text = dict["start_button"][2];
        quitButtonText.text = dict["quit_button"][2];
        mainButtonText.text = "ES";
        is_open = false;
        languages.SetActive(false);
    }
}
