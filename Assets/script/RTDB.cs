using UnityEngine;
using Firebase.Database;
using TMPro;
using System.Collections;


public class RTDB : MonoBehaviour
{
    [SerializeField] TMP_InputField username;
    [SerializeField] TMP_InputField email;
    [SerializeField] TMP_InputField nametoread;
    [SerializeField] TextMeshProUGUI data;
    string kanjiPercentage; 
    
    TextMeshProUGUI selectedPercentage;   
    
    StartScene KanjiValues;
    string PulledData;
    string UpdatedName;
    // Start is called before the first frame update

    User user = new User();
    void Start() 
    {
        UpdatedName = "";
        KanjiValues = GameObject.Find("GM").GetComponent<StartScene>();
        selectedPercentage = GameObject.Find("SuccessPercentage").GetComponent<TextMeshProUGUI>();
    }

    void Update() 
    {
        data.text = UpdatedName;
    }
    public void savedata()
    {
        user.UserName = username.text;
        user.Email = email.text;
        user.Ichi = KanjiValues.IchiPercentage;
        user.Ni = KanjiValues.NiPercentage;
        user.San = KanjiValues.SanPercentage;
        user.Yon = KanjiValues.YonPercentage;
        user.Go = KanjiValues.GoPercentage;
        user.Roku = KanjiValues.RokuPercentage;
        user.Nana = KanjiValues.NanaPercentage;
        user.Hachi = KanjiValues.HachiPercentage;
        user.Juu = KanjiValues.JuuPercentage;
        user.Hi = KanjiValues.HiPercentage;

        string json = JsonUtility.ToJson(user);

        FirebaseDatabase.DefaultInstance.RootReference.Child("User").Child(user.UserName).SetRawJsonValueAsync(json).ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("successfully added data to firebase");
            }
            else
            {
                Debug.Log("not successfull");
            }
        });
    }

    public void Read_Data(string KanjiQuery)
    {
        StartCoroutine(waiter(KanjiQuery));
    }

    public void SetText(string PulledData)
    {        
        selectedPercentage.text = PulledData;
    }
    IEnumerator waiter(string KanjiQuery)
    {        
        print(" starting corroutine ");

        FirebaseDatabase.DefaultInstance.RootReference.Child("User").Child("fu1").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("successfull");
                DataSnapshot snapshot = task.Result;
                PulledData = snapshot.Child(KanjiQuery).Value.ToString();
            }
            else
            {
                Debug.Log("not successfull");
            }
        });
        yield return new WaitForSeconds(1);
        print(" finishing corroutine ");
        SetText(PulledData);
    }
}
