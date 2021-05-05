using UnityEngine;
using System.Collections.Generic;
public class DialogueTrigger : MoveMenu 
{
	public List<screenplayInfo> dialogue;
	Sprite CharacterVessel;
	public Sprite CharacterSprite = null;
	[Range(1, 2)]
	public int CharacterPosition = 1;

	void OnMouseDown() 
    {     
		TriggerDialogue();
        OpenDialog(); 		
    }

	public void TriggerDialogue()
	{
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);		
	}

	public void SetCharacter()
	{
		CharacterVessel = GameObject.Find("Char"+CharacterPosition).GetComponent<SpriteRenderer>().sprite = CharacterSprite;
	}

	public void SetivateCharacterCollision(bool enabledCollider, int positionCollider)
	{
		GameObject.Find("Char"+positionCollider).GetComponent<BoxCollider>().enabled = enabledCollider;
	}
}