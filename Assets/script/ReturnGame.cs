using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReturnGame : MonoBehaviour
{    
    public UnityEvent OtherFunctions;
    MoveCamera moveCamera;
    AfterLabScript afterLabScript;
    // Start is called before the first frame update
    void Start() 
    {        
        moveCamera = GameObject.Find("GM").GetComponent<MoveCamera>();
        afterLabScript = GameObject.Find("GM").GetComponent<AfterLabScript>();
    }
	void OnMouseDown(){
        moveCamera.MoveToScene();
        FindObjectOfType<DialogueManager>().StartDialogue(afterLabScript.screenplay);
        CallOtherFunctions();
    }

    void CallOtherFunctions()
    {
        OtherFunctions.Invoke();
    }
}
