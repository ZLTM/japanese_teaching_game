using UnityEngine.Events;
using UnityEngine;
public class StartScene : MonoBehaviour
{
    public UnityEvent OtherFunctions;
    PrologueScript prologueScript;
    void Start()
    {
        prologueScript = this.GetComponent<PrologueScript>();
        FindObjectOfType<DialogueManager>().StartDialogue(prologueScript.screenplay);
        CallOtherFunctions();
    }

    void CallOtherFunctions()
    {
        OtherFunctions.Invoke();
    }
}
