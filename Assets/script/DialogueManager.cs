using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
    int charDialogue = 0;
    List<int> numberDialogue = new List<int>();
    int i = 0;
    int j = 1;
    private Image BlockButton;
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
        dialogueTrigger.SetCharacter(characterImage, position, mirror);
        UnityEvent OtherFunction = OtherFunctions.Peek();
        // CallOtherFunctions(OtherFunction);

        string name = names.Peek();
        nameText.text = name; 
        
        if (j <= numberDialogue[charDialogue])
        {
            print("sentences"+sentences);
            
            if(sentences.Count > 0)
            {
                string sentence = sentences.Dequeue();
                print("sentence"+sentence);
                dialogueText.text = sentence;
                j++;
            }
            else
            {
                EndDialogue();
            }
            
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

/* Typing animation for letters 
sentence: string containing the full dialogue line*/
/*  
to delete
    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    } */

/* Triggers a close dialogue */
    void EndDialogue ()
    {
        CloseDialogBox();
    }

/* Closes the dialogue box */
    public void CloseDialogBox()
    {
        OpenDialog(); 
    }

    /* Allows to call a function set from the inspector */
    public void CallOtherFunctions(UnityEvent OtherFunction)
    {
        OtherFunction.Invoke();
    }

    /* Switch button image state blocking and unblocking the dialogue */
    public void SwitchDialogButton(string State)
    {
        print("switching");
        BlockButton = GameObject.Find("ButtonBlock").GetComponent<Image>();
        BlockButton.enabled  = bool.Parse(State);
    }

}