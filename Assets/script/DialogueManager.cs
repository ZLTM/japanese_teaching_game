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
    List<int> numberFunction = new List<int>();
    int countSentence = 0;
    int countFunctions = 0;
    int sentenceCount = 1;
    
    int functionCount = 1;
    int k = 0;
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
        characterImages.Clear();
        mirrors.Clear();
        positions.Clear();
        OtherFunctions.Clear();

        k = 0;
        charDialogue = 0;
        countFunctions = 0;
        foreach (screenplayInfo screenplay in screenplayInfo)
        {
            numberDialogue.Add(999);
            numberDialogue[charDialogue] = 0;

            numberFunction.Add(999);
            numberFunction[charDialogue] = 0;

            names.Enqueue(screenplay.name);
            characterImages.Enqueue(screenplay.CharacterImage);
            mirrors.Enqueue(screenplay.mirrowed);
            positions.Enqueue(screenplay.CharacterPosition);

            if (screenplay.sentences.Count > 0)
            {
                foreach (string sentence in screenplay.sentences)
                {
                    sentences.Enqueue(sentence);
                    countSentence++;
                }
            }

            if (screenplay.OtherFunctions.Count > 0)
            {
                foreach (UnityEvent func in screenplay.OtherFunctions)
                {
                    if (func != null)
                    {
                        OtherFunctions.Enqueue(func);
                        countFunctions++;
                    }
                }
            }

            numberDialogue[charDialogue] = countSentence;
            numberFunction[charDialogue] = countFunctions;
            countSentence = 0;
            countFunctions = 0;
            charDialogue++;
        }
        DisplayNextSentence();
    }

/* displays sentences and changes character according to the screenplay */
    public void DisplayNextSentence()
    {

        Sprite characterImage = characterImages.Peek();
        int position = positions.Peek();
        bool mirror = mirrors.Peek();
        dialogueTrigger.SetCharacter(characterImage, position, mirror);

        string name = names.Peek();
        nameText.text = name; 


        
        if (sentences.Count > 0)  
        {
            if(functionCount <= numberFunction[k] && OtherFunctions.Count > 0)  
            {
                UnityEvent func = OtherFunctions.Dequeue();
                CallOtherFunctions(func);
                functionCount++;
            }


            if(sentenceCount <= numberDialogue[k])  
            {
                string sentence = sentences.Dequeue();
                dialogueText.text = sentence;
                sentenceCount++;
            }
            else
            {
                characterImages.Dequeue();
                positions.Dequeue();
                mirrors.Dequeue();
                names.Dequeue();
                
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
                    dialogueTrigger.SetCharacter(characterImage, position, mirror);

                    sentenceCount=1; 
                    functionCount=1;
                    k++;
                    // DisplayNextSentence();
                }
            }
        }   
        else
        {
            EndDialogue(); 
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
        names.Clear();
        sentences.Clear();
        characterImages.Clear();
        mirrors.Clear();
        positions.Clear();
        OtherFunctions.Clear();
        
        charDialogue = 0;
        countSentence = 0;
        countFunctions = 0;
        sentenceCount = 1;
        functionCount = 1;
        k = 0;

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
        BlockButton = GameObject.Find("ButtonBlock").GetComponent<Image>();
        BlockButton.enabled  = bool.Parse(State);
    }

}