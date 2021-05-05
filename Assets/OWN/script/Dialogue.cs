using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;

    [TextArea(3, 10)]
    public List<string> sentences = new List<string>();

    public void CloseDialogBox()
    {
        GameObject DialogBox = GameObject.FindWithTag("DialogBox"); 
        int destination = -100;    
        iTween.MoveBy(DialogBox, iTween.Hash("y", destination, "easeType", "easeOutExpo", "delay", 0.1f));
    }
}
