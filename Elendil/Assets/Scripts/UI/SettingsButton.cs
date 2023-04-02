using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
    public GameObject childButtons;
    public AudioSource musicSource;
    public bool musicEnabled = true;
    public Text buttonText;

    void Start()
    {
        // Находим объект musicSource в сцене
        musicSource = GameObject.FindObjectOfType<AudioSource>();

        // Скрываем дочерние кнопки при запуске сцены
        childButtons.SetActive(false);

        // Получаем ссылку на компонент Text на кнопке
        buttonText = GetComponentInChildren<Text>();

    }

    public void ToggleChildButtons()
    {
        // Изменяем состояние дочерних кнопок при нажатии на родительскую кнопку
        childButtons.SetActive(!childButtons.activeSelf);
    }

    public void ToggleMusic()
    {
        // Инвертируем состояние музыки
        musicEnabled = !musicEnabled;

        if (musicEnabled)
        {
            // Включаем звук, если он был выключен
            musicSource.Play();
        }
        else
        {
            // Выключаем звук, если он был включен
            musicSource.Stop();
        }
    }
}
