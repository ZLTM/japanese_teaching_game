using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MoveMenu {

	public Dialogue dialogue;

	void OnMouseDown() 
    {     
		TriggerDialogue();
        OpenDialog("open"); 		
    }

	public void TriggerDialogue ()
	{
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);		
	}

}