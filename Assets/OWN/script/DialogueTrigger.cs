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