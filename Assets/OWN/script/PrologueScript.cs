using System.Collections.Generic;
using UnityEngine;

public class PrologueScript : MonoBehaviour
{
    public List<screenplayInfo> screenplay = new List<screenplayInfo>();
}

[System.Serializable]
public class screenplayInfo
{    
    public string name;
    public Sprite CharacterImage;
    public bool mirrowed;

    [Range(1, 2)]
	public int CharacterPosition = 1;
    public List<string> sentences;
}

