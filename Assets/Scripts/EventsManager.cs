using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventsManager : MonoBehaviour
{
    public GameObject AppButton;
    public GameObject MainMenuContent;
    // Start is called before the first frame update
    void Start()
    {
        Events.InitiateMenu(AppButton, MainMenuContent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
