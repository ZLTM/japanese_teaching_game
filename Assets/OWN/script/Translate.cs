using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Translate : MoveMenu
{
    public TextMeshProUGUI TMPText;

    public string LastClickedWord;

    public List<string> Target;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var wordIndex = TMP_TextUtilities.FindIntersectingWord(TMPText, Input.mousePosition, null);

            if (wordIndex != -1)
            {
                LastClickedWord = TMPText.textInfo.wordInfo[wordIndex].GetWord();

                if (Target.Contains(LastClickedWord))
                {
                    Debug.Log("Clicked on " + LastClickedWord);
                    TMPText.text = "aa";
                    GameObject Inventory = GameObject.FindWithTag("Inventory");             
                    OpenMenu("open");     
                }          
            }
        }
    }
}