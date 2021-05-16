using System.Collections.Generic;
using UnityEngine;
using TMPro;
using RotaryHeart.Lib.SerializableDictionary;

[System.Serializable]
public class initKanjiDict : SerializableDictionaryBase<string, string> 
{
    
}
public class KanjiDict : MonoBehaviour
{
    public initKanjiDict kanjiRomanji;
}
