using Firebase;
using Firebase.Database;
using UnityEngine;
using UnityEngine.Events;
public class FirebaseInit : MonoBehaviour
{
    void Start() 
    {
    // Get the root reference location of the database.
    DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
    print(reference);
    }
}
