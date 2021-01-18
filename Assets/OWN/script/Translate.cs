using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Translate : MoveMenu
{
    public TextMeshProUGUI TMPTextDialog;
    TextMeshProUGUI TMPTextTranslation;

    public string LastClickedWord;

    public List<string> Target;

    void Start()
    {
        TMPTextTranslation = GameObject.Find("dialogTranslation").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var wordIndex = TMP_TextUtilities.FindIntersectingWord(TMPTextDialog, Input.mousePosition, null);

            if (wordIndex != -1)
            {
                LastClickedWord = TMPTextDialog.textInfo.wordInfo[wordIndex].GetWord();

                if (Target.Contains(LastClickedWord))
                {
                    TMPTextTranslation.text = LastClickedWord;   
                    TranslateCharacters translateCharacters = GameObject.Find("Translation").GetComponent<TranslateCharacters>();
                    translateCharacters.SetSelectedString();       
                    OpenKana("open");  
                    OpenTranslation("open");
                }          
            }
        }
    }
}