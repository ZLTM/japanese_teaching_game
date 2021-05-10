using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    Camera cam;
    GameObject target;

    // Update is called once per frame

    public void MoveToPuzzle() 
    {
        cam = GameObject.Find("MainCamera").GetComponent<Camera>();
        target = GameObject.Find("PuzzleTarget");
        cam.transform.position = target.transform.position;               
    }

}
