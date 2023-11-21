using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    // public GameObject AppButton;
    // public GameObject MainMenuContent;
    // public GameObject Debug;
    public GameObject searchBar;
    public GameObject CommentInput;
    public GameObject CommentPrefab;
    public GameObject AppPage;
    void Start()
    {
        // TDD test for initiate main menu
        // Dictionary<string, App> appRepository = new AppRepository().GetApps();
        // Events.InitiateMenu(AppButton, MainMenuContent);
        // if (appRepository[" Your Music"].GetName() == null) {
        //     Debug.GetComponent<TextMeshProUGUI>().text = "Error";
        // }
        // Debug.GetComponent<TextMeshProUGUI>().text = appRepository[" Your Music"].GetName();
        CommentInput.GetComponent<TMP_InputField>().onEndEdit.AddListener(onEndEditHandler);

    }

    private void onEndEditHandler(string arg0)
    {
        Events.WriteComment(AppPage, CommentInput, CommentPrefab);
        Console.WriteLine("asdfasdfdsafasdf");
    }

    void Update()
    {
        TextMeshProUGUI searchText = searchBar.GetComponentInChildren<TextMeshProUGUI>();
        string a = searchText.text;
        //Debug.Log(a);  
    }
}
