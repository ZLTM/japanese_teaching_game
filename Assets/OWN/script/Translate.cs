using System.Collections.Generic;
using UnityEngine;
using TMPro;
using RotaryHeart.Lib.SerializableDictionary;
[System.Serializable]
public class MyDictionary : SerializableDictionaryBase<string, string> { 
}

public class Translate : MoveMenu
{
    public MyDictionary KanjiValue;
    public TextMeshProUGUI TMPTextDialog;
    TextMeshProUGUI TMPTextTranslation;

    public string LastClickedWord;

    string kanji;
    string romanji;

    void Start()
    {
        TMPTextTranslation = GameObject.Find("dialogTranslation").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            foreach (string value in KanjiValue.Values)
            {
                romanji = value;
            }

            foreach (string value in KanjiValue.Keys)
            {
                kanji = value;
            }
            
            var wordIndex = TMP_TextUtilities.FindIntersectingWord(TMPTextDialog, Input.mousePosition, null);

            if (wordIndex != -1)
            {
                LastClickedWord = TMPTextDialog.textInfo.wordInfo[wordIndex].GetWord();

                if (kanji == LastClickedWord)
                {
                    TMPTextTranslation.text = LastClickedWord;   
                    TranslateCharacters translateCharacters = GameObject.Find("Translation").GetComponent<TranslateCharacters>();
                    OpenTranslation();
                    // translateCharacters.CheckCharacter(kanji, romanji);
                }
            }
        }
    }
}