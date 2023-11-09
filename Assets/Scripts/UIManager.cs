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
    
    void Start() {
        SearchBar.GetComponent<InputField>().onEndEdit.AddListener(OnInputFieldEndEdit);
    }

    public void Login() {
        //isSearch = false;
        SearchBar.GetComponent<TextMeshProUGUI>().text = "";
        LoginPage.SetActive(true);
        MainMenu.SetActive(false);
        CategoryPage.SetActive(false);
        AppPage.SetActive(false);
        SearchPage.SetActive(false);
    }

    public void Discover() {
        //isSearch = false;
        SearchBar.GetComponent<TextMeshProUGUI>().text = "";
        MainMenu.SetActive(true);
        CategoryPage.SetActive(false);
        LoginPage.SetActive(false);
        AppPage.SetActive(false);
        SearchPage.SetActive(false);
    }

    public void Categories() {
        //isSearch = false;
        SearchBar.GetComponent<TextMeshProUGUI>().text = "";
        CategoryPage.SetActive(true);
        MainMenu.SetActive(false);
        LoginPage.SetActive(false);
        AppPage.SetActive(false);
        SearchPage.SetActive(false);
    }

    public void ViewApp(AppObject appObject) {
        //isSearch = false;
        SearchBar.GetComponent<TextMeshProUGUI>().text = "";
        Events.InitiateAppPage(AppPage, appObject);
        AppPage.SetActive(true);
        MainMenu.SetActive(false);
        CategoryPage.SetActive(false);
        LoginPage.SetActive(false);
        SearchPage.SetActive(false);
    }

    public void Search() {
        SearchPage.SetActive(true);
        LoginPage.SetActive(false);
        MainMenu.SetActive(false);
        CategoryPage.SetActive(false);
        AppPage.SetActive(false);
    }
}
