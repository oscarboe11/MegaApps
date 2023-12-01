using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EventsManager : MonoBehaviour
{
    public GameObject AppButton;
    public GameObject SearchMenuContent;
    public GameObject SearchBar;
    public GameObject CategoriesDropDown;
    public GameObject CategoriesContent;
    
    void Start()    
    {
        Events.InitiateCategoryOptions(CategoriesDropDown);
        Debug.Log(Application.platform.ToString());

    }
    void Update() {
        // TextMeshProUGUI searchText = SearchBar.GetComponentInChildren<TextMeshProUGUI>();
        // Events.InitiateSearchPage(AppButton, MainMenuContent, searchText.text);
        // TextMeshProUGUI searchText = SearchBar.GetComponentInChildren<TextMeshProUGUI>();
        // string searchTextString;
        // if(searchText.text.Length > 0) {
        //     searchTextString = searchText.text.Substring(0, searchText.text.Length - 1);
        //     Events.SearchApps(searchTextString);
    }
    
    void FixedUpdate() {
        Events.InitiateSearchPage(AppButton, SearchMenuContent, SearchBar);
        Events.InitiateCategoryMenu(AppButton, CategoriesContent, CategoriesDropDown);
    }
}
