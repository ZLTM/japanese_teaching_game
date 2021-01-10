using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMenu : MonoBehaviour
{
    double destination = 0f;

    // Update is called once per frame

    public void OpenMenu(string order)
    {
        GameObject Inventory = GameObject.FindWithTag("Inventory");
        if (order == "open")
        {
            destination = -210;
        }
        else
        {
            destination = 210;
        }        
        iTween.MoveBy(Inventory, iTween.Hash("x", destination, "easeType", "easeOutExpo", "delay", 0.1f));
    }

    public void OpenDialog(string order)
    {
        GameObject DialogBox = GameObject.FindWithTag("DialogBox"); 
        if (order == "open")
        {
            destination = 100;
        }
        else
        {
            destination = -100;
        }        
        iTween.MoveBy(DialogBox, iTween.Hash("y", destination, "easeType", "easeOutExpo", "delay", 0.1f));
    }

}
