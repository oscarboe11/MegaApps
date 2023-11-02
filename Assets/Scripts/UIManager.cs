using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject LoginPage;
    public GameObject MainMenu;
    public GameObject CategoryPage;
    public GameObject AppPage;
    
    // Use for general test.
    void Start() {
        //AppRepository ar = new AppRepository();
    }

    // public void CreateRep() {
    //     AppRepository ar = new AppRepository();
    // }

    public void Login() {
        if(!LoginPage.activeSelf) {
            LoginPage.SetActive(true);
            MainMenu.SetActive(false);
            CategoryPage.SetActive(false);
            AppPage.SetActive(false);
        }
    }

    public void Discover() {
        MainMenu.SetActive(true);
        CategoryPage.SetActive(false);
        LoginPage.SetActive(false);
        AppPage.SetActive(false);
    }

    public void Categories() {
        CategoryPage.SetActive(true);
        MainMenu.SetActive(false);
        LoginPage.SetActive(false);
        AppPage.SetActive(false);
    }

    public void ViewApp(AppObject appObject) {
        Events.InitiateAppPage(AppPage, appObject);
        AppPage.SetActive(true);
        MainMenu.SetActive(false);
        CategoryPage.SetActive(false);
        LoginPage.SetActive(false);
    }
}
