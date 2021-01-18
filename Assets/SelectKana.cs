using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectKana : MonoBehaviour
{
  public char Kana;
    public void SendKana() 
    {     
      TranslateCharacters translateCharacters = GameObject.Find("Translation").GetComponent<TranslateCharacters>();
      translateCharacters.CheckCharacter(Kana);
    }
}
