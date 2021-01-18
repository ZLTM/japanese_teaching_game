using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectKana : MonoBehaviour
{
  public char Kana;
  public char Romaji;
    public void SendKana() 
    {     
      TranslateCharacters translateCharacters = GameObject.Find("Translation").GetComponent<TranslateCharacters>();
      translateCharacters.CheckCharacter(Kana, Romaji);
    }
}
