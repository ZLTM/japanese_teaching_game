using UnityEngine.Events;
using UnityEngine;
using System.Collections.Generic;
public class StartScene : MonoBehaviour
{
    public UnityEvent OtherFunctions;
    public double IchiSuccess;
    public double IchiFailure;
    [System.NonSerialized]
    public double IchiPercentage;
    public double NiSuccess;
    public double NiFailure;
    [System.NonSerialized]
    public double NiPercentage;
    public double SanSuccess;
    public double SanFailure;
    [System.NonSerialized]
    public double SanPercentage;
    public double YonSuccess;
    public double YonFailure;
    [System.NonSerialized]
    public double YonPercentage;
    public double GoSuccess;
    public double GoFailure;
    [System.NonSerialized]
    public double GoPercentage;
    public double RokuSuccess;
    public double RokuFailure;
    [System.NonSerialized]
    public double RokuPercentage;
    public double NanaSuccess;
    public double NanaFailure;
    [System.NonSerialized]
    public double NanaPercentage;
    public double HachiSuccess;
    public double HachiFailure;
    [System.NonSerialized]
    public double HachiPercentage;
    public double JuuSuccess;
    public double JuuFailure;
    [System.NonSerialized]
    public double JuuPercentage;
    public double HiSuccess;
    public double HiFailure;
    [System.NonSerialized]
    public double HiPercentage;
    // public List<KanjiRatings> kanjiRatings = new List<KanjiRatings>();
    PrologueScript prologueScript;
    void Awake() 
    {
        IchiPercentage = IchiSuccess/(IchiSuccess+IchiFailure);
        NiPercentage = NiSuccess/(NiSuccess+NiFailure);
        SanPercentage = SanSuccess/(SanSuccess+SanFailure);
        YonPercentage = YonSuccess/(YonSuccess+YonFailure);
        GoPercentage = GoSuccess/(GoSuccess+GoFailure);
        RokuPercentage = RokuSuccess/(RokuSuccess+RokuFailure);
        NanaPercentage = NanaSuccess/(NanaSuccess+NanaFailure);
        HachiPercentage = HachiSuccess/(HachiSuccess+HachiFailure);
        JuuPercentage = JuuSuccess/(JuuSuccess+JuuFailure);
        HiPercentage = HiSuccess/(HiSuccess+HiFailure);
    }
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

    void Update() 
    {
        IchiPercentage = IchiSuccess/(IchiSuccess+IchiFailure);
        NiPercentage = NiSuccess/(NiSuccess+NiFailure);
        SanPercentage = SanSuccess/(SanSuccess+SanFailure);
        YonPercentage = YonSuccess/(YonSuccess+YonFailure);
        GoPercentage = GoSuccess/(GoSuccess+GoFailure);
        RokuPercentage = RokuSuccess/(RokuSuccess+RokuFailure);
        NanaPercentage = NanaSuccess/(NanaSuccess+NanaFailure);
        HachiPercentage = HachiSuccess/(HachiSuccess+HachiFailure);
        JuuPercentage = JuuSuccess/(JuuSuccess+JuuFailure);
        HiPercentage = HiSuccess/(HiSuccess+HiFailure);
    }

}

