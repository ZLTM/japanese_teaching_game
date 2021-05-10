using UnityEngine;
using TMPro;

public class TranslateCharacters : MonoBehaviour
{
    string TMPTextTranslation;
    string TMPTInputField;
    KanjiDict kanjiDict;
    TouchScreenKeyboard keyboard;
    string keyboardValue;

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
}
