using UnityEngine;
using Firebase.Database;
using TMPro;
using UnityEngine.UI; 
using System.Threading.Tasks;
using Google;

public class RTDB : MonoBehaviour
{
    
    StartScene KanjiValues;
    string PulledName;
    string UpdatedName;
    private GoogleSignInConfiguration configuration;
    // Start is called before the first frame update

    User user = new User();
    
    GoogleSignInUser googleSignInUser;

    void Start() 
    {
        UpdatedName = "";
        KanjiValues = GameObject.Find("GM").GetComponent<StartScene>();
        // Save_Data();
        print(KanjiValues.IchiPercentage);
    }

    void update() {
        
        KanjiValues = GameObject.Find("GM").GetComponent<StartScene>();
        print(KanjiValues.IchiPercentage);
    }

    public void Save_Data() 
    {
        GoogleSignIn.DefaultInstance.SignIn().ContinueWith(
        savedata);
    }
    internal void savedata(Task<GoogleSignInUser> task)
    {
        user.UserId = task.Result.UserId;
        // user.Email = googleSignInUser.Email;
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

        FirebaseDatabase.DefaultInstance.RootReference.Child(user.UserId).SetRawJsonValueAsync(json).ContinueWith(task =>
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
        FirebaseDatabase.DefaultInstance.RootReference.Child(user.UserId).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("successfull");
                DataSnapshot snapshot = task.Result;
                PulledName = snapshot.Child(KanjiQuery).Value.ToString();
                Debug.Log("user: "+snapshot.Child("UserId").Value.ToString());
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