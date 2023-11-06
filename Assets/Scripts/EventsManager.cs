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
    
    void Start()    
    {
        Events.InitiateMenu(AppButton, MainMenuContent);
    }

    void Update()
    {
        Events.SearchApps();
    }

    void FixedUpdate() {
        
    }

    void Awake() {

    }
}
