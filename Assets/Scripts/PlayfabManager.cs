using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;

public class PlayfabManager : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text message;
    public TMP_Text loginText;
    public TMP_InputField userName;
    public TMP_InputField userPsw;

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

    void OnRegisterSuccess(RegisterPlayFabUserResult result) {
        message.text = "Registered and logged in!";
    }

    public void Login() {
        var request = new LoginWithPlayFabRequest {
            Username = userName.text,
            Password = userPsw.text,
        };
        PlayFabClientAPI.LoginWithPlayFab(request, OnLoginSuccess, OnError);
    }

    void OnLoginSuccess(LoginResult result) {
        message.text = "Successful login!";
        loginText.text = "Hi, " + userName.text;
    }

    void OnError(PlayFabError error) {
        message.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }

}
