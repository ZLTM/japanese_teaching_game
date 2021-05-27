using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeInput : MonoBehaviour
{
    string answer;
    CodeSolution codeSolution;
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume=0.5f;
    // Start is called before the first frame update
    void Start()
    {
        codeSolution = GameObject.Find("Labblock").GetComponent<CodeSolution>();
    }
	void OnMouseDown()
    {
        audioSource.PlayOneShot(clip, volume); 
        answer = this.name;
        codeSolution.CheckSolution(answer);
	}
}
