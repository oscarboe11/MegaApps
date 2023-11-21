using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject LoginPage;
    public GameObject MainMenu;
    public GameObject CategoryPage;
    public GameObject AppPage;
    public GameObject SearchPage;
    public GameObject SearchBar;
    public GameObject CommentInput;
    public GameObject CommentPrefab;
    
    void Start() {
        SearchBar.GetComponent<TMP_InputField>().onValueChanged.AddListener(onSearchEndEditHandler);
        CommentInput.GetComponent<TMP_InputField>().onEndEdit.AddListener(onCommentEndEditHandler);
    }

    private void onSearchEndEditHandler(string arg0)
    {
        Search();
    }

    private void onCommentEndEditHandler(string arg0)
    {
        Events.WriteComment(AppPage, CommentInput, CommentPrefab);
    }

    public void Login() {
        LoginPage.SetActive(true);
        MainMenu.SetActive(false);
        CategoryPage.SetActive(false);
        AppPage.SetActive(false);
        SearchPage.SetActive(false);
    }

    public void Discover() {
        MainMenu.SetActive(true);
        CategoryPage.SetActive(false);
        LoginPage.SetActive(false);
        AppPage.SetActive(false);
        SearchPage.SetActive(false);
    }

    public void Categories() {
        CategoryPage.SetActive(true);
        MainMenu.SetActive(false);
        LoginPage.SetActive(false);
        AppPage.SetActive(false);
        SearchPage.SetActive(false);
    }

    public void ViewApp(AppObject appObject) {
        Events.InitiateAppPage(AppPage, appObject, CommentPrefab);
        AppPage.SetActive(true);
        MainMenu.SetActive(false);
        CategoryPage.SetActive(false);
        LoginPage.SetActive(false);
        SearchPage.SetActive(false);
    }

    void Search() {
        SearchPage.SetActive(true);
        LoginPage.SetActive(false);
        MainMenu.SetActive(false);
        CategoryPage.SetActive(false);
        AppPage.SetActive(false);
    }
}
