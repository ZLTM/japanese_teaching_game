using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabDetails : MonoBehaviour
{
    public Sprite puzzleImage; 
    [SerializeField] [TextArea] public string title; 
    [SerializeField] [TextArea] public string description; 
}
