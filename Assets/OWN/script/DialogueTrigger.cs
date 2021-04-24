public class DialogueTrigger : MoveMenu {

	public Dialogue dialogue;

	void OnMouseDown() 
    {     
		TriggerDialogue();
        OpenDialog(); 		
    }

	public void TriggerDialogue ()
	{
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);		
	}

}