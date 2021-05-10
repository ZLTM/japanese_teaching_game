using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using TMPro;

[System.Serializable]
public class DialogueManager : MoveMenu {
    public TextMeshProUGUI  nameText;
    public TextMeshProUGUI  dialogueText;
    DialogueTrigger dialogueTrigger;
    private Queue<string> sentences;
    private Queue<string> names;
    private Queue<bool> mirrors;
    private Queue<int> positions;
    private Queue<Sprite> characterImages;
    private Queue<UnityEvent> OtherFunctions;
    // int charName = 0;
    int charDialogue = 0;
    List<int> numberDialogue = new List<int>();
    int i = 0;
    int j = 1;
    void Awake () {
		sentences = new Queue<string>();
        names = new Queue<string>();
        characterImages = new Queue<Sprite>();
		mirrors = new Queue<bool>();
        positions = new Queue<int>();
        OtherFunctions = new Queue<UnityEvent>();
        dialogueTrigger = GameObject.Find("Char1").GetComponent<DialogueTrigger>();
	}

/* sets dialogue display for  DisplayNextSentence
screenplayInfo: recieves object list including:
    */
    public void StartDialogue (List<screenplayInfo> screenplayInfo)
	{
        names.Clear();
        sentences.Clear();
        foreach (screenplayInfo screenplay in screenplayInfo)
        {
            numberDialogue.Add(999);
            numberDialogue[charDialogue] = 0;

            characterImages.Enqueue(screenplay.CharacterImage);
            names.Enqueue(screenplay.name);
            positions.Enqueue(screenplay.CharacterPosition);
            OtherFunctions.Enqueue(screenplay.OtherFunctions);
            mirrors.Enqueue(screenplay.mirrowed);

            foreach (string sentence in screenplay.sentences)
            {
                sentences.Enqueue(sentence);
                i++;
            }
            numberDialogue[charDialogue] = i;
            charDialogue++;
            i=0;
        }
        DisplayNextSentence();
    }

/* displays sentences and changes character according to the screenplay */
    public void DisplayNextSentence()
    {
        charDialogue=0;

        Sprite characterImage = characterImages.Peek();
        int position = positions.Peek();
        bool mirror = mirrors.Peek();
        UnityEvent OtherFunction = OtherFunctions.Peek();
        dialogueTrigger.SetCharacter(characterImage, position, mirror);
        CallOtherFunctions(OtherFunction);

        string name = names.Peek();
        nameText.text = name; 
        
        if (j <= numberDialogue[charDialogue])
        {
            string sentence = sentences.Dequeue();
            dialogueText.text = sentence;
            j++;
        }
        else
        {
            characterImages.Dequeue();
            positions.Dequeue();
            mirrors.Dequeue();
            names.Dequeue();
            OtherFunctions.Dequeue();
            if(names.Count==0)
            {
                EndDialogue(); 
            }
            else
            {
                name = names.Peek(); 
                nameText.text = name;

                characterImage = characterImages.Peek();
                position = positions.Peek();
                mirror = mirrors.Peek();
                position = positions.Peek();
                OtherFunction = OtherFunctions.Peek();
                dialogueTrigger.SetCharacter(characterImage, position, mirror);
                CallOtherFunctions(OtherFunction);

                j=1; 
                DisplayNextSentence();
            }
        }      
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

    void CallOtherFunctions(UnityEvent OtherFunction)
    {
        OtherFunction.Invoke();
    }
}