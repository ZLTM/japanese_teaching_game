using UnityEngine;
using TMPro;

public class TranslateCharacters : MonoBehaviour
{
    string TMPTextTranslation;
    string TMPTInputField;
    KanjiDict kanjiDict;
    TouchScreenKeyboard keyboard;
    string keyboardValue;
    RTDB rtdb;

    void Start()
    {
        kanjiDict = GameObject.Find("GM").GetComponent<KanjiDict>();
    }
    public void SetSelectedString(string originalText, string translatedText)
    {
        print("SelectedString: "+translatedText);
        GameObject.Find("dialogTranslation").GetComponent<TextMeshProUGUI>().text = originalText + " " + translatedText;
    }

    public void CheckCharacter()
    {
        TMPTextTranslation = GameObject.Find("dialogTranslation").GetComponent<TextMeshProUGUI>().text;
        TMPTInputField = GameObject.Find("InputField").GetComponent<TMP_InputField>().text;
        foreach (string key in kanjiDict.kanjiRomanji.Keys)
        {
            if(TMPTextTranslation == key)
            {
                if (TMPTInputField.Trim() == kanjiDict.kanjiRomanji[key].Trim())
                {
                    SetSelectedString(TMPTextTranslation, TMPTInputField);
                }
                else
                {
                    print("wrong translation try again");
                }
            }
        }
    }
    public void CorrecTranslation(string Romanji)
    {
        switch (Romanji)
        {
        case "Ichi":
            this.GetComponent<StartScene>().IchiSuccess++;
            break;
        case "Ni":
            this.GetComponent<StartScene>().NiSuccess++;
            break;
        case "San":
            this.GetComponent<StartScene>().SanSuccess++;
            break;
        case "Yon":
            this.GetComponent<StartScene>().YonSuccess++;
            break;
        case "Go":
            this.GetComponent<StartScene>().GoSuccess++;
            break;
        case "Roku":
            this.GetComponent<StartScene>().RokuSuccess++;
            break;
        case "Nana":
            this.GetComponent<StartScene>().NanaSuccess++;
            break;
        case "Hachi":
            this.GetComponent<StartScene>().HachiSuccess++;
            break;
        case "Juu":
            this.GetComponent<StartScene>().JuuSuccess++;
            break;
        case "Hi":
            this.GetComponent<StartScene>().HiSuccess++;
            break;
        default:
            print ("Incorrect romanji.");
            break;
        }
    }
}
