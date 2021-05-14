using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnGame : MonoBehaviour
{
    
    MoveCamera moveCamera;
    // Start is called before the first frame update
	void OnMouseDown(){
        moveCamera = GameObject.Find("GM").GetComponent<MoveCamera>();
        moveCamera.MoveToScene();
	}
}
