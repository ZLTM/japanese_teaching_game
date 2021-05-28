// <copyright file="SigninSampleScript.cs" company="Google Inc.">
// Copyright (C) 2017 Google Inc. All Rights Reserved.
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations

namespace SignInSample {
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Google;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Database;

public class GoogleSignin : MonoBehaviour {

public Text statusText;

public string webClientId = "<your client id here>";

private GoogleSignInConfiguration configuration;

GoogleSignInUser googleSignInUser;
StartScene KanjiValues;

// Defer the configuration creation until Awake so the web Client ID
// Can be set via the property inspector in the Editor.
void Awake() {
    configuration = new GoogleSignInConfiguration {
        WebClientId = webClientId,
        RequestIdToken = true
    };
    OnSignIn();
    KanjiValues = GameObject.Find("GM").GetComponent<StartScene>();
}


public void OnSignIn() {
    GoogleSignIn.Configuration = configuration;
    GoogleSignIn.Configuration.UseGameSignIn = false;
    GoogleSignIn.Configuration.RequestIdToken = true;
    AddStatusText("Calling SignIn");

    GoogleSignIn.DefaultInstance.SignIn().ContinueWith(
    OnAuthenticationFinished);
}

public void OnSignOut() {
    AddStatusText("Calling SignOut");
    GoogleSignIn.DefaultInstance.SignOut();
}

public void OnDisconnect() {
    AddStatusText("Calling Disconnect");
    GoogleSignIn.DefaultInstance.Disconnect();
}

internal void OnAuthenticationFinished(Task<GoogleSignInUser> task) {
    if (task.IsFaulted) {
    using (IEnumerator<System.Exception> enumerator =
            task.Exception.InnerExceptions.GetEnumerator()) {
        if (enumerator.MoveNext()) {
        GoogleSignIn.SignInException error =
                (GoogleSignIn.SignInException)enumerator.Current;
        AddStatusText("Got Error: " + error.Status + " " + error.Message);
        } else {
        AddStatusText("Got Unexpected Exception?!?" + task.Exception);
        }
    }
    } else if(task.IsCanceled) {
        AddStatusText("Canceled");
    } else  
    {
        GameObject.Find("GM").GetComponent<StartScene>().id = task.Result.UserId;

        user.UserId = task.Result.UserId;
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

        AddStatusText("Welcome: " + task.Result.DisplayName + "!");
                string json = JsonUtility.ToJson(user);

        FirebaseDatabase.DefaultInstance.RootReference.Child(task.Result.UserId).SetRawJsonValueAsync(json).ContinueWith(task =>
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
}

public void OnSignInSilently() {
    GoogleSignIn.Configuration = configuration;
    GoogleSignIn.Configuration.UseGameSignIn = false;
    GoogleSignIn.Configuration.RequestIdToken = true;
    AddStatusText("Calling SignIn Silently");

    GoogleSignIn.DefaultInstance.SignInSilently()
        .ContinueWith(OnAuthenticationFinished);
}


public void OnGamesSignIn() {
    GoogleSignIn.Configuration = configuration;
    GoogleSignIn.Configuration.UseGameSignIn = true;
    GoogleSignIn.Configuration.RequestIdToken = false;

    AddStatusText("Calling Games SignIn");

    GoogleSignIn.DefaultInstance.SignIn().ContinueWith(
    OnAuthenticationFinished);
}

private List<string> messages = new List<string>();
User user = new User();
void AddStatusText(string text) {

    if (messages.Count == 5) {
    messages.RemoveAt(0);
    }
    messages.Add(text);
    string txt = "";
    foreach (string s in messages) {
    txt += "\n" + s;
    }
    statusText.text = txt;
}
}
}
