using UnityEngine;
using Firebase.Database;
using TMPro;
using UnityEngine.UI; 

public class RTDB : MonoBehaviour
{
    [SerializeField] TMP_InputField username;
    [SerializeField] TMP_InputField email;
    [SerializeField] TMP_InputField nametoread;
    [SerializeField] TextMeshProUGUI data;
    string PulledName;
    string UpdatedName;
    // Start is called before the first frame update

    User user = new User();
    void Start() 
    {
        UpdatedName = "";
    }

    void Update() 
    {
        data.text = UpdatedName;
    }
    public void savedata()
    {
        user.UserName = username.text;
        user.Email = email.text;
        user.Ichi = "0";
        user.Ni = "0";
        user.San = "0";
        user.Yon = "0";
        user.Go = "0";
        user.Roku = "0";
        user.Nana = "0";
        user.Hachi = "0";
        user.Juu = "0";
        user.Hi = "0";

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

    public void Read_Data()
    {
        FirebaseDatabase.DefaultInstance.RootReference.Child("User").Child(nametoread.text).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("successfull");
                DataSnapshot snapshot = task.Result;
                PulledName = snapshot.Child("UserName").Value.ToString();
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
