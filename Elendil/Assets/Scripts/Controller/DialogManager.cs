using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [System.Serializable]
    public struct Dialog
    {
        public string charName;
        public string charText;
    }

    public DialogContainer dialogContainer;

    public GameObject DialogPrefab;

    public Image Char1Image;
    public Image Char2Image;
    public Text Char1Text;
    public Text Char2Text;
    public Text DialogText;
    public Button NextText;
    public int index = 0;
    public float speedText;
    public Color shadowColor;
    public Color originalColor = Color.white;
    public string defaultChar2Text;
    public bool isCheacked = false;
    private PlayerController player;
    public bool needPause = false;
    public bool DialogEnd = false;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        shadowColor = HexToColor("#8C8C8C");
        DialogText.text = string.Empty;
        Char1Text.text = "Хиро";
        Char2Text.text = defaultChar2Text;
        Char1Image.color = shadowColor;
        Char2Image.color = shadowColor;
        //startDialog();
    }
    public void scipTextClick(){
        if(DialogText.text == dialogContainer.phrases[index].charText){
            NextLines();
        }else{
            StopAllCoroutines();
            DialogText.text = dialogContainer.phrases[index].charText;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == Tag.PLAYER && !isCheacked){
            startDialog();
        }
    }
    public void startDialog(){
        if(!isCheacked){
            index = 0;
            DialogPrefab.SetActive(true);
            isCheacked = true;
            player.canRun = false;
            StartCoroutine(TypeLine());
        }
    }
    public void NextLines(){
        if(index < dialogContainer.phrases.Length - 1){
            index++;
            DialogText.text = string.Empty;
            StartCoroutine(TypeLine());
        }else{
            DialogEnd = true;
            DialogPrefab.SetActive(false);
            player.canRun = true;
        }
    }

    IEnumerator TypeLine(){

        if(dialogContainer.phrases[index].charName == "Хиро"){
            Char1Image.color = originalColor;
            Char2Image.color = shadowColor;
        }else{
            Char2Text.text = dialogContainer.phrases[index].charName;
            Char1Image.color = shadowColor;
            Char2Image.color = originalColor;
        }

        foreach(char c in dialogContainer.phrases[index].charText){
            DialogText.text += c;
            yield return new WaitForSeconds(speedText);
        }
    }

    private Color HexToColor(string hex)
    {
        Color color = Color.grey; // Цвет по умолчанию, если процесс преобразования не удался

        if (ColorUtility.TryParseHtmlString(hex, out Color parsedColor))
        {
            color = parsedColor;
        }

        return color;
    }
}

[System.Serializable]
public class DialogContainer
{
    public DialogManager.Dialog[] phrases;

    public DialogContainer(int numDialogs)
    {
        phrases = new DialogManager.Dialog[numDialogs];
    }
}
