using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject LoginPage;
    public GameObject MainMenu;
    public GameObject CategoryPage;
    
    public void Login() {
        if(!LoginPage.activeSelf) {
            LoginPage.SetActive(true);
            MainMenu.SetActive(false);
        }
    }

    public void Discover() {
        MainMenu.SetActive(true);
        CategoryPage.SetActive(false);
        LoginPage.SetActive(false);
    }

    public void Categories() {
        CategoryPage.SetActive(true);
        MainMenu.SetActive(false);
        LoginPage.SetActive(false);
    }
}
