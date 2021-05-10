using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDrop : MonoBehaviour
{
    public string answer;
    bool AState = false;
    bool BState = false;
    bool CState = false;
    public bool State = false;
    bool updatedState;
    MoveCamera moveCamera;

    void Update()
    {
        if (AState && BState && CState)
        {
            moveCamera = GameObject.Find("GM").GetComponent<MoveCamera>();
            moveCamera.MoveToScene();
        }
    }

    void UpdateState()
    {
        this.State = true;
        AState = GameObject.Find("A").GetComponent<TargetDrop>().State;
        BState = GameObject.Find("B").GetComponent<TargetDrop>().State;
        CState = GameObject.Find("C").GetComponent<TargetDrop>().State;
    }
    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.name == answer)
        {
            UpdateState();
        }
    }
}
