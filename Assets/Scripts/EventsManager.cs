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

    }
    
    void FixedUpdate() {
        Events.InitiateSearchPage(AppButton, SearchMenuContent, SearchBar);
        Events.InitiateCategoryMenu(AppButton, CategoriesContent, CategoriesDropDown);
    }
}
