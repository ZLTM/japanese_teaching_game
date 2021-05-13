using UnityEngine;
using Firebase.Database;
using TMPro;
using UnityEngine.UI; 

public class RTDB : MonoBehaviour
{
    // [SerializeField] TMP_InputField username;
    // [SerializeField] TMP_InputField email;
    // [SerializeField] TMP_InputField nametoread;
    // [SerializeField] TextMeshProUGUI data;
    
    StartScene KanjiValues;
    string PulledName;
    string UpdatedName;
    // Start is called before the first frame update

    User user = new User();
    void Start() 
    {
        UpdatedName = "";
        KanjiValues = GameObject.Find("GM").GetComponent<StartScene>();
    }

    void Update() 
    {
        // data.text = UpdatedName;
    }
    public void savedata()
    {
        // user.UserName = username.text;
        // user.Email = email.text;
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
        FirebaseDatabase.DefaultInstance.RootReference.Child("User").Child("fu1").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("successfull");
                DataSnapshot snapshot = task.Result;
                PulledName = snapshot.Child(KanjiQuery).Value.ToString();
                Debug.Log("user: "+snapshot.Child("UserName").Value.ToString());
                Debug.Log("email: "+snapshot.Child("Email").Value.ToString());
            }
            else
            {
                Debug.Log("not successfull");
            }
            SetText(PulledName);
        });
    }

    public void SetText(string UsedName)
    {
        UpdatedName = UsedName;
    }
}