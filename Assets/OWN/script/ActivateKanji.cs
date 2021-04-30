using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateKanji : MonoBehaviour
{
    public string ObjectName;
    GameObject Item;

    public void ActivateItem()
    {
        Item = GameObject.Find(ObjectName);
        Item.SetActive(true);
    }
}
