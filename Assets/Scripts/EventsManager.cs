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
    public GameObject MainMenuContent;
    public GameObject SearchBar;
    
    void Start()    
    {
        Events.InitiateMenu(AppButton, MainMenuContent);
    }

    void Update()
    {
        TextMeshProUGUI searchText = SearchBar.GetComponentInChildren<TextMeshProUGUI>();
        Events.SearchApps(searchText.text);
    }

    void FixedUpdate() {
        
    }

    void Awake() {

    }
}
