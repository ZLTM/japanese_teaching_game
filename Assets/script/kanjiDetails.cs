using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kanjiDetails : MonoBehaviour
{
    [SerializeField] [TextArea] public string Readings; 
    [SerializeField] [TextArea] public string Description; 
    [System.NonSerialized] public double Percentage; 
}
