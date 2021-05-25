using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class PrologueScript : MonoBehaviour
{
    public List<screenplayInfo> screenplay = new List<screenplayInfo>();
}
/* properties of every screenplay paragraph */

[System.Serializable]
public class screenplayInfo
{    
    public string name;
    public Sprite CharacterImage;
    public bool mirrowed;

    [Range(1, 2)]
	public int CharacterPosition = 1;
    public List<UnityEvent> OtherFunctions;
    public List<string> sentences;
}

