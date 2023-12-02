using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject AppButton;
    public GameObject PendingAppButton;
    public GameObject LoginPage;
    public GameObject MainMenu;
    public GameObject CategoryPage;
    public GameObject AppPage;
    public GameObject SearchPage;
    public GameObject SearchBar;
    public GameObject CommentInput;
    public GameObject CommentPrefab;
    public GameObject AddAppPage;
    public GameObject PendingAppPage;
    public GameObject AppTemplatePage;
    public GameObject AddAppAdmin;
    public GameObject MainMenuContent;
    public GameObject PendingListContent;
    [Header("Message")]
    public GameObject LoginPageMessage;
    public GameObject AppPageMessage;
    public GameObject AddAppPageMessage;
    
    void Start() {
        Events.InitiateMenu(AppButton, MainMenuContent);
        Events.InitiatePendingList(PendingAppButton, PendingListContent);
        SearchBar.GetComponent<TMP_InputField>().onValueChanged.AddListener(onSearchEndEditHandler);
        CommentInput.GetComponent<TMP_InputField>().onEndEdit.AddListener(onCommentEndEditHandler);
    }

    private void onSearchEndEditHandler(string arg0)
    {
        Search();
    }

    private void onCommentEndEditHandler(string arg0)
    {
        GameObject user = GameObject.Find("User");
        if(user.GetComponent<User>().GetPermission() == "") {
            TextMeshProUGUI message = GameObject.Find("AppPageMessage").GetComponent<TextMeshProUGUI>();
            message.text = "You need to log in to comment.";
            CommentInput.GetComponent<TMP_InputField>().text = "";
            return;
        }
        Events.WriteComment(AppPage, CommentInput, CommentPrefab);
        CommentInput.GetComponent<TMP_InputField>().text = "";
    }

    public void Login() {
        LoginPage.SetActive(true);
        MainMenu.SetActive(false);
        CategoryPage.SetActive(false);
        AppPage.SetActive(false);
        SearchPage.SetActive(false);
        AddAppPage.SetActive(false);
        PendingAppPage.SetActive(false);
        AppTemplatePage.SetActive(false);
        UpdateMessage();
    }

    public void Discover() {
        Events.UpdateMainMenu(AppButton, MainMenuContent);
        MainMenu.SetActive(true);
        CategoryPage.SetActive(false);
        LoginPage.SetActive(false);
        AppPage.SetActive(false);
        SearchPage.SetActive(false);
        AddAppPage.SetActive(false);
        PendingAppPage.SetActive(false);
        AppTemplatePage.SetActive(false);
        UpdateMessage();
    }

    public void Categories() {
        CategoryPage.SetActive(true);
        MainMenu.SetActive(false);
        LoginPage.SetActive(false);
        AppPage.SetActive(false);
        SearchPage.SetActive(false);
        AddAppPage.SetActive(false);
        PendingAppPage.SetActive(false);
        AppTemplatePage.SetActive(false);
        UpdateMessage();
    }

    public void ViewApp(AppObject appObject) {
        Events.InitiateAppPage(AppPage, appObject, CommentPrefab);
        AppPage.SetActive(true);
        MainMenu.SetActive(false);
        CategoryPage.SetActive(false);
        LoginPage.SetActive(false);
        SearchPage.SetActive(false);
        AddAppPage.SetActive(false);
        PendingAppPage.SetActive(false);
        AppTemplatePage.SetActive(false);
    }

    public void ViewPendingApp(AppObject appObject) {
        Events.InitiatePendingAppPage(PendingAppPage, appObject);
        PendingAppPage.SetActive(true);
        AppPage.SetActive(false);
        MainMenu.SetActive(false);
        CategoryPage.SetActive(false);
        LoginPage.SetActive(false);
        SearchPage.SetActive(false);
        AddAppPage.SetActive(false);
        AppTemplatePage.SetActive(false);
    }

    public void Search() {
        SearchPage.SetActive(true);
        LoginPage.SetActive(false);
        MainMenu.SetActive(false);
        CategoryPage.SetActive(false);
        AppPage.SetActive(false);
        AddAppPage.SetActive(false);
        PendingAppPage.SetActive(false);
        AppTemplatePage.SetActive(false);
        UpdateMessage();
    }

    public void AddApp() {
        Events.UpdatePendingList(PendingAppButton, PendingListContent);
        AddAppPage.SetActive(true);
        MainMenu.SetActive(false);
        CategoryPage.SetActive(false);
        LoginPage.SetActive(false);
        AppPage.SetActive(false);
        SearchPage.SetActive(false);
        PendingAppPage.SetActive(false);
        AppTemplatePage.SetActive(false);
        UpdateMessage();
    }

    public void AppRequest() {
        GameObject user = GameObject.Find("User");
        if(user.GetComponent<User>().GetPermission() == "") {
            TextMeshProUGUI message = GameObject.Find("AddAppsPageMessage").GetComponent<TextMeshProUGUI>();
            message.text = "You need to log in to add apps.";
            return;
        }
        AppTemplatePage.SetActive(true);
        LoginPage.SetActive(false);
        MainMenu.SetActive(false);
        CategoryPage.SetActive(false);
        AppPage.SetActive(false);
        SearchPage.SetActive(false);
        AddAppPage.SetActive(false);
        PendingAppPage.SetActive(false);
    }

    public void SubmitRequest() {
        Events.SubmitAppRequest(AppTemplatePage);
        AddApp();
    }

    public void Approve() {
        Events.ApproveNewApp(AddAppAdmin);
        AddApp();
    }

    public void Reject() {
        Events.RejectNewApp(AddAppAdmin);
        AddApp();
    }

    private void UpdateMessage() {
        LoginPageMessage.GetComponent<TextMeshProUGUI>().text = " ";
        AppPageMessage.GetComponent<TextMeshProUGUI>().text = " ";
        AddAppPageMessage.GetComponent<TextMeshProUGUI>().text = " ";
    }
}
