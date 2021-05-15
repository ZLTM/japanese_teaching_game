using UnityEngine;
using System.Collections.Generic;
public class DialogueTrigger : MoveMenu 
{
	public List<screenplayInfo> dialogue;
	GameObject CharacterVessel;

	void OnMouseDown() 
    {     
		TriggerDialogue();
        OpenDialog(); 		
    }

	public void TriggerDialogue()
	{
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);		
	}

	public void SetCharacter(Sprite CharacterImage, int CharacterPosition, bool CharacterMirror)
	{
		CharacterVessel = GameObject.Find("Char"+CharacterPosition);

		CharacterVessel.GetComponent<SpriteRenderer>().sprite = CharacterImage;
		CharacterVessel.GetComponent<SpriteRenderer>().flipX = CharacterMirror;
	}

/* 	to delete
	public void SetivateCharacterCollision(bool enabledCollider, int positionCollider)
	{
		GameObject.Find("Char"+positionCollider).GetComponent<BoxCollider>().enabled = enabledCollider;
	} */
}