using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using Unity.VisualScripting;

// used to communicate with PlayFab database where users are stored
public class PlayfabManager : MonoBehaviour {
    [Header("UI")]
    public TMP_Text message;
    public TMP_Text loginText;
    public TMP_InputField userName;
    public TMP_InputField userPsw;
    public GameObject User;

    // Set and get user's permission.
    public void SetAdminPermission() {
        var request = new UpdateUserDataRequest {
            Data = new Dictionary<string, string> {
                {"Permission", "Admin"}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
    }

    public void SetModPermission() {
        var request = new UpdateUserDataRequest {
            Data = new Dictionary<string, string> {
                {"Permission", "Admin"}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
    }

    public void SetUserPermission() {
        var request = new UpdateUserDataRequest {
            Data = new Dictionary<string, string> {
                {"Permission", "User"}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
    }
    
    public void GetPermission() {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataRecieved, OnError);
    }

    void OnDataSend(UpdateUserDataResult result) {
        Debug.Log("Permission Set.");
    }

    void OnDataRecieved(GetUserDataResult result) {
        Debug.Log("Reciedved User Permission.");
        if(result.Data != null && result.Data.ContainsKey("Permission")) {
            Debug.Log(result.Data["Permission"].Value);
            User.GetComponent<User>().SetPermission(result.Data["Permission"].Value);
            Debug.Log("User permission set to: " + User.GetComponent<User>().GetPermission());
        }
        else {
            User.GetComponent<User>().SetPermission("User");
        }
    }

    // Register and Login
    public void Register() {
        if(userName.text.Length < 3) {
            message.text = "User name must at least has 3 characters.";
            return;
        }
        else if(userPsw.text.Length < 6) {
            message.text = "User Password must at least has 6 characters.";
            return;
        }

        var request = new RegisterPlayFabUserRequest {
            Username = userName.text,
            Password = userPsw.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }

    public void Login() {
        var request = new LoginWithPlayFabRequest {
            Username = userName.text,
            Password = userPsw.text,
        };
        PlayFabClientAPI.LoginWithPlayFab(request, OnLoginSuccess, OnError);
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result) {
        message.text = "Registered and logged in!";
        loginText.text = "Hi, " + userName.text;
        SetUserPermission();
        GetPermission();
    }

    void OnLoginSuccess(LoginResult result) {
        message.text = "Successful login!";
        loginText.text = "Hi, " + userName.text;
        GetPermission();
    }

    // Error Message.
    void OnError(PlayFabError error) {
        message.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }

}
