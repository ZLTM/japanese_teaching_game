using UnityEngine;
using TMPro;
using System.Collections;

public class TranslateCharacters : MoveMenu
{
    string TMPTextTranslation;
    string TMPTInputField;
    KanjiDict kanjiDict;
/*     TouchScreenKeyboard keyboard;
    string keyboardValue;
    RTDB rtdb; */
    DialogueManager dialogueManager;

    void Start()
    {
        kanjiDict = GameObject.Find("GM").GetComponent<KanjiDict>();
        dialogueManager = GameObject.Find("GM").GetComponent<DialogueManager>();
    }
    public void SetSelectedString(string originalText, string translatedText)
    {
        GameObject.Find("dialogTranslation").GetComponent<TextMeshProUGUI>().text = originalText + " " + translatedText;
    }

    public void CheckCharacter()
    {
        TMPTextTranslation = GameObject.Find("dialogTranslation").GetComponent<TextMeshProUGUI>().text;
        TMPTInputField = GameObject.Find("InputField").GetComponent<TMP_InputField>().text;
        foreach (string key in kanjiDict.kanjiRomanji.Keys)
        {
            key.ToLower();
            TMPTextTranslation.ToLower();
            if(TMPTextTranslation == key)
            {
                if (TMPTInputField.Trim() == kanjiDict.kanjiRomanji[key].Trim())
                {
                    SetSelectedString(TMPTextTranslation, TMPTInputField);
                    dialogueManager.SwitchDialogButton("False");
                    StartCoroutine(WaitTranslation());
                    CorrectTranslation(TMPTInputField);
                }
                else
                {
                    print("wrong translation try again");
                    IncorrectTranslation(TMPTInputField);
                }
            }
        }
    }

    IEnumerator WaitTranslation ()
    {
        yield return new WaitForSeconds(2);
        OpenTranslation();
    }

    /* Update succes rate on local, prepares data for DB */
    public void CorrectTranslation(string Romanji)
    {
        Romanji.ToLower();
        switch (Romanji)
        {
        case "ichi":
            this.GetComponent<StartScene>().IchiSuccess++;
            break;
        case "ni":
            this.GetComponent<StartScene>().NiSuccess++;
            break;
        case "san":
            this.GetComponent<StartScene>().SanSuccess++;
            break;
        case "yon":
            this.GetComponent<StartScene>().YonSuccess++;
            break;
        case "go":
            this.GetComponent<StartScene>().GoSuccess++;
            break;
        case "roku":
            this.GetComponent<StartScene>().RokuSuccess++;
            break;
        case "nana":
            this.GetComponent<StartScene>().NanaSuccess++;
            break;
        case "hachi":
            this.GetComponent<StartScene>().HachiSuccess++;
            break;
        case "juu":
            this.GetComponent<StartScene>().JuuSuccess++;
            break;
        case "hi":
            this.GetComponent<StartScene>().HiSuccess++;
            break;
        default:
            print ("Incorrect romanji.");
            break;
        }
    }

    public void IncorrectTranslation(string Romanji)
    {
        Romanji.ToLower();
        switch (Romanji)
        {
        case "ichi":
            this.GetComponent<StartScene>().IchiFailure++;
            break;
        case "ni":
            this.GetComponent<StartScene>().NiFailure++;
            break;
        case "san":
            this.GetComponent<StartScene>().SanFailure++;
            break;
        case "yon":
            this.GetComponent<StartScene>().YonFailure++;
            break;
        case "go":
            this.GetComponent<StartScene>().GoFailure++;
            break;
        case "roku":
            this.GetComponent<StartScene>().RokuFailure++;
            break;
        case "nana":
            this.GetComponent<StartScene>().NanaFailure++;
            break;
        case "hachi":
            this.GetComponent<StartScene>().HachiFailure++;
            break;
        case "juu":
            this.GetComponent<StartScene>().JuuFailure++;
            break;
        case "hi":
            this.GetComponent<StartScene>().HiFailure++;
            break;
        default:
            print ("Incorrect romanji.");
            break;
        }
    }
}
