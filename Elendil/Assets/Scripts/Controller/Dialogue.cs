using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct DialogueLine
{
    public string charName;
    public string charText;
    public Sprite charImage;
}

[System.Serializable]
public class DialogueContainer
{
    public DialogueLine[] phrases;

    public DialogueContainer(int numDialogs)
    {
        phrases = new DialogueLine[numDialogs];
    }
}

public class Dialogue : MonoBehaviour
{
    public DialogueContainer DialogueContainer;
    public GameObject DialoguePrefab;
    public Image image;
    public Text DialogueText;
    public Button NextText;
    public int index = 0;
    public float speedText;
    private bool isStarted = false;
    public GameObject loadingScreen;
    public Slider slider;

    public void Start ()
    {
        StartDialogue ();
    }

    public void StartDialogue()
    {
        if (!isStarted)
        {
            index = 0;
            DialoguePrefab.SetActive(true);
            isStarted = true;
            StartCoroutine(TypeLine());
        }
    }

    public void NextLines()
    {
        if (index < DialogueContainer.phrases.Length - 1)
        {
            index++;
            DialogueText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            //DialoguePrefab.SetActive(false);
            StartCoroutine(LoadingScreenOnFade(SceneManager.GetActiveScene().buildIndex + 1));
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void ScipTextClick()
    {
        if (DialogueText.text == DialogueContainer.phrases[index].charText)
        {
            NextLines();
        }
        else
        {
            StopAllCoroutines();
            DialogueText.text = DialogueContainer.phrases[index].charText;
        }
    }

    IEnumerator TypeLine()
    {
        image.sprite = DialogueContainer.phrases[index].charImage;

        foreach (char c in DialogueContainer.phrases[index].charText)
        {
            DialogueText.text += c;
            yield return new WaitForSeconds(speedText);
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
