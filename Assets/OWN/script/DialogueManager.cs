using System.Collections;
using System.Collections.Generic;
using TMPro;

[System.Serializable]
public class DialogueManager : MoveMenu {
    public TextMeshProUGUI  nameText;
    public TextMeshProUGUI  dialogueText;
    private Queue<string> sentences;
    private Queue<string> names;
    void Awake () {
		sentences = new Queue<string>();
        names = new Queue<string>();
	}

    public void StartDialogue (List<screenplayInfo> screenplayInfo)
	{
        names.Clear();
        sentences.Clear();
        foreach (screenplayInfo screenplay in screenplayInfo)
        {
            print(screenplay.name);
            names.Enqueue(screenplay.name);
            // print(screenplay.mirrowed);
            // print(screenplay.CharacterPosition);
            foreach (string sentence in screenplay.sentences)
            {
                sentences.Enqueue(sentence);
            }
        }
        DisplayNextSentence();
        DisplayNextName();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            DisplayNextName();
        }
        string sentence = sentences.Dequeue();
        print("on display"+sentence);
        dialogueText.text = sentence;
    }

    public void DisplayNextName()
    {
        if (names.Count == 0)
        {
            EndDialogue();
            return;
        }
        string name = names.Dequeue();
        nameText.text = name;
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue ()
    {
        CloseDialogBox();
    }

    public void CloseDialogBox()
    {
        OpenDialog(); 
    }
}