using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TranslateCharacters : MonoBehaviour
{
    public string SelectedString;
    Queue<char> SelectedQueue = new Queue<char>();

    public void SetSelectedString()
    {
        SelectedString = GameObject.Find("dialogTranslation").GetComponent<TextMeshProUGUI>().text;

        foreach (char Character in SelectedString)
        {
            print("adding" + Character);
            SelectedQueue.Enqueue(Character);
        }
    }

    public void CheckCharacter(char Kana)
    {      
        print("checking queue "+"char"+SelectedQueue.Peek()+" kana"+Kana);
        if(SelectedQueue.Peek()  == Kana)
        {
            print("Deleting char"+SelectedQueue.Peek());
            SelectedQueue.Dequeue();
        }
        
        if(SelectedQueue.Count == 0)
        {
            print("translated!!!");
        }
    }
}
