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
    GameObject BlockButton;

    void Start()
    {
        BlockButton = GameObject.Find("Puzzleblock");
    }
    void Update()
    {
        if (AState && BState && CState)
        {
            moveCamera = GameObject.Find("GM").GetComponent<MoveCamera>();
            BlockButton.SetActive(false);
        }
    }

    void UpdateState()
    {
        this.State = true;
        AState = GameObject.Find("A").GetComponent<TargetDrop>().State;
        BState = GameObject.Find("B").GetComponent<TargetDrop>().State;
        CState = GameObject.Find("C").GetComponent<TargetDrop>().State;
    }
    void OnTriggerEnter (Collider other)
    {
        if(other.name == answer)
        {
            UpdateState();
        }
    }
}
