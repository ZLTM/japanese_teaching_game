using UnityEngine;
using Firebase.Database;
using TMPro;
using UnityEngine.UI; 

public class RTDB : MonoBehaviour
{
    [SerializeField] TMP_InputField username;
    [SerializeField] TMP_InputField email;
    [SerializeField] TMP_InputField nametoread;
    [SerializeField] Text data;
    // Start is called before the first frame update

    User user = new User();
    public void savedata()
    {
        user.UserName = username.text;
        user.Email = email.text;
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
                print("username is");
                Debug.Log( snapshot.Child("UserName").Value.ToString());
                print("email is");
                Debug.Log(snapshot.Child("Email").Value.ToString());

            }
            else
            {
                Debug.Log("not successfull");
            }
        });
    }
}
