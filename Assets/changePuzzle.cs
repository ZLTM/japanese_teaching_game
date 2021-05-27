using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class changePuzzle : MonoBehaviour
{
    Sprite PuzzleImage;
    string puzzleTitle;
    TextMeshProUGUI targetTitle;
    string puzzleDescription;
    TextMeshProUGUI targetDescription;  
    Image selectedPuzzle;
    // Start is called before the first frame update
    public void SelectPuzzle()
    {
        puzzleTitle = GameObject.Find("GM").GetComponent<safeDetails>().title;
        targetTitle = GameObject.Find("PuzzleTitle").GetComponent<TextMeshProUGUI>();
        targetTitle.text = puzzleTitle;

        puzzleDescription = GameObject.Find("GM").GetComponent<safeDetails>().description;
        targetDescription = GameObject.Find("PuzzleDescription").GetComponent<TextMeshProUGUI>();
        targetDescription.text = puzzleDescription;

        PuzzleImage = GameObject.Find("GM").GetComponent<safeDetails>().puzzleImage;
        selectedPuzzle = GameObject.Find("PuzzleImage").GetComponent<Image>();
        selectedPuzzle.sprite = PuzzleImage;
    }
}
