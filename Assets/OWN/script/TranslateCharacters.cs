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
        SelectedString = GameObject.Find("InputText").GetComponent<TextMeshProUGUI>().text;
        print("SelectedString"+SelectedString);
        TranslatedText = "";
        TranslatedGui = GameObject.Find("InputText").GetComponent<TMP_Text>();
    }

    public void CheckCharacter(string romanji)
    {      
/*         print("checking queue "+"char"+SelectedQueue.Peek()+" Kanji"+Kanji);
        if(SelectedQueue.Peek()  == Kanji)
        {
            TranslatedText += Romanji;
            print("Deleting char"+SelectedQueue.Peek());
            SelectedQueue.Dequeue();
        }
        
        if(SelectedQueue.Count == 0)
        {
            TranslatedGui.text = TranslatedText;
            print(TranslatedText);
        } */
    }
}
