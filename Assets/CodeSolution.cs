using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeSolution : MonoBehaviour
{
    List<string> solution = new List<string>();
    public List<string> answer = new List<string>();
    GameObject BlockButton;
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume=0.5f;
    // Start is called before the first frame update
    void Start()
    {
        BlockButton = GameObject.Find("Labblock");
        solution.Add("PressIchi");
        solution.Add("PressHachi");
        solution.Add("PressIchi");
        solution.Add("PressSan");
    }
    public void CheckSolution(string answerPart)
    {
        answer.Add(answerPart);
        print(answer.Count);
        if (answer.Count >= 4)
        {
            print(answer[1]);
            print(solution[1]);
            if ( answer[0] == solution[0] && answer[1] == solution[1] && answer[2] == solution[2] && answer[3] == solution[3] )
            {
                BlockButton.SetActive(false);
            }
            else
            {
                audioSource.PlayOneShot(clip, volume); 
                answer.Clear();
            }
        }
    }
}
