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

    List<string> kanjis = new List<string>(); 
    List<string> romanjis = new List<string>();

    void Start()
    {
        TMPTextTranslation = GameObject.Find("dialogTranslation").GetComponent<TextMeshProUGUI>();
        foreach (string value in KanjiValue.Values)
        {
            romanjis.Add(value);
        }

        foreach (string value in KanjiValue.Keys)
        {
            kanjis.Add(value);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {            
            var wordIndex = TMP_TextUtilities.FindIntersectingWord(TMPTextDialog, Input.mousePosition, null);
            print("worindex "+wordIndex);

            if (wordIndex != -1)
            {
                
                print("inside if ");
                LastClickedWord = TMPTextDialog.textInfo.wordInfo[wordIndex].GetWord();

                foreach (var kanji in kanjis)
                {
                    if (kanji == LastClickedWord)
                    {
                        print("opening translation");
                        TMPTextTranslation.text = LastClickedWord;
                        OpenTranslation();
                    }
                }

            }
        }
    }
}