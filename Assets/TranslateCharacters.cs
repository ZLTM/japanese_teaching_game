using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TranslateCharacters : MonoBehaviour
{
    public string SelectedString;
    Queue<char> SelectedQueue = new Queue<char>();
    string TranslatedText;
    private TMP_Text TranslatedGui;

    public void SetSelectedString()
    {
        SelectedString = GameObject.Find("dialogTranslation").GetComponent<TextMeshProUGUI>().text;
        TranslatedText = "";
        TranslatedGui = GameObject.Find("dialogTranslation").GetComponent<TMP_Text>();

        foreach (char Character in SelectedString)
        {
            print("adding" + Character);
            SelectedQueue.Enqueue(Character);
        }
    }

    public void CheckCharacter(char Kana, char Romanji)
    {      
        print("checking queue "+"char"+SelectedQueue.Peek()+" kana"+Kana);
        if(SelectedQueue.Peek()  == Kana)
        {
            TranslatedText += Romanji;
            print("Deleting char"+SelectedQueue.Peek());
            SelectedQueue.Dequeue();
        }
        
        if(SelectedQueue.Count == 0)
        {
            TranslatedGui.text = TranslatedText;
            print(TranslatedText);
        }
    }
}
