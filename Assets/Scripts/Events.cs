using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PlayFab.DataModels;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Events : MonoBehaviour
{
    private static Dictionary<string, App> appRepository = new AppRepository().GetApps();
    public GameObject searchBar;
    
    public static void InitiateMenu(GameObject prefab, GameObject parent) {
        if (prefab != null && parent != null) {
            foreach (KeyValuePair<string, App> app in appRepository) {
                GameObject AppButton = Instantiate(prefab, parent.GetComponent<Transform>());
                AppButton.GetComponent<AppObject>().SetAppInfo(app.Value); 
                //Debug.Log(app.Value.getName());
                TextMeshProUGUI  ButtonText = AppButton.GetComponentInChildren<TextMeshProUGUI>();
                if(ButtonText != null) {
                    // ButtonText.text = app.Value.GetName();
                    ButtonText.text = AppButton.GetComponent<AppObject>().GetAppInfo().GetName();
                }
            }
        }
    }

    public static void InitiateAppPage(GameObject AppPage, AppObject appObject) {
        App app = appObject.GetAppInfo();
        GameObject gameObject = AppPage.transform.Find("Info").Find("Name").gameObject;
        gameObject.GetComponent<TextMeshProUGUI>().text = app.GetName();

        gameObject = AppPage.transform.Find("Info").Find("Description").gameObject;
        gameObject.GetComponent<TextMeshProUGUI>().text = "Description: " + app.GetDescription();

        gameObject = AppPage.transform.Find("Info").Find("Organization").gameObject;
        gameObject.GetComponent<TextMeshProUGUI>().text = "Organization: " + app.GetOrganization();

        gameObject = AppPage.transform.Find("Info").Find("Platform").gameObject;
        gameObject.GetComponent<TextMeshProUGUI>().text = "Description: " + app.GetPlatform();

        gameObject = AppPage.transform.Find("Info").Find("Version").gameObject;
        gameObject.GetComponent<TextMeshProUGUI>().text = "Version: " + app.GetVersion();
        //Debug.Log(app.GetVersion());

        gameObject = AppPage.transform.Find("Info").Find("Category").gameObject;
        gameObject.GetComponent<TextMeshProUGUI>().text = "Category: " + app.GetCategory();

        gameObject = AppPage.transform.Find("Info").Find("Link").gameObject;
        gameObject.GetComponent<TextMeshProUGUI>().text = "Link: " + app.GetLink();

        gameObject = AppPage.transform.Find("Info").Find("Price").gameObject;
        gameObject.GetComponent<TextMeshProUGUI>().text = "Price: " + app.GetPrice();
    }

    public static void InitiateSearchPage(GameObject prefab, GameObject parent, GameObject SearchBar) {
        string searchText = SearchBar.GetComponentInChildren<TextMeshProUGUI>().text;
        if(searchText.Length > 1) {
            searchText = searchText.Substring(0, searchText.Length - 1);
            Dictionary<string, App> searchResults = SearchAppRepository(searchText);
            DeleteAppButton(parent, searchResults);
            if (prefab != null && parent != null) {
                foreach (KeyValuePair<string, App> app in searchResults) {
                    if(CheckAppButtonExist(parent, app)) {
                        continue;
                    }
                    
                    GameObject AppButton = Instantiate(prefab, parent.GetComponent<Transform>());
                    AppButton.GetComponent<AppObject>().SetAppInfo(app.Value); 
                    //Debug.Log(app.Value.getName());
                    TextMeshProUGUI  ButtonText = AppButton.GetComponentInChildren<TextMeshProUGUI>();
                    if(ButtonText != null) {
                        // ButtonText.text = app.Value.GetName();
                        ButtonText.text = AppButton.GetComponent<AppObject>().GetAppInfo().GetName();
                    }
                }
            }
        }
    }

    // private static void DeleteAppButton(GameObject parent, Dictionary<string, App> searchApp) {
    //     Transform parentTransform = parent.transform;
    //     if(parentTransform.childCount > 0) {
    //         for (int i = 0; i < parentTransform.childCount; i++) {
    //             // Access each child using the GetChild method
    //             GameObject child = parentTransform.GetChild(i).gameObject;
    //             if(!searchApp.ContainsKey(child.GetComponent<AppObject>().GetAppInfo().GetName())) {
    //                 Destroy(child);
    //             }
    //         }
    //     }
    // }

    private static void DeleteAppButton(GameObject parent, Dictionary<string, App> searchApp) {
    Transform parentTransform = parent.transform;
    if (parentTransform.childCount > 0) {
        for (int i = 0; i < parentTransform.childCount; i++) {
            GameObject child = parentTransform.GetChild(i).gameObject;
            AppObject appObject = child.GetComponent<AppObject>();
            
            if (appObject != null) {
                App appInfo = appObject.GetAppInfo();
                
                if (appInfo != null && !searchApp.ContainsKey(appInfo.GetName())) {
                    Destroy(child);
                }
            }
        }
    }
}

    private static void DeleteAppButton(GameObject parent, List<string> apps) {
        Transform parentTransform = parent.transform;
        if(parentTransform.childCount > 0) {
            for (int i = 0; i < parentTransform.childCount; i++) {
                // Access each child using the GetChild method
                GameObject child = parentTransform.GetChild(i).gameObject;
                if(!apps.Contains(child.GetComponent<AppObject>().GetAppInfo().GetName())) {
                    Destroy(child);
                }
            }
        }
    }

    private static bool CheckAppButtonExist(GameObject parent, KeyValuePair<string, App> app) {
        bool isExist = false;
        Transform parentTransform = parent.transform;
        if(parentTransform.childCount > 0) {
            for (int i = 0; i < parentTransform.childCount; i++) {
                // Access each child using the GetChild method
                GameObject child = parentTransform.GetChild(i).gameObject;
            AppObject appObject = child.GetComponent<AppObject>();
            if (appObject != null && appObject.GetAppInfo() != null &&
                app.Value.GetName() == appObject.GetAppInfo().GetName()) {
                isExist = true;
            }
            }
        }
        return isExist;
    } 

    private static Dictionary<string, App> SearchAppRepository(string searchTerms) {
        Dictionary<string, App> searchResults = new Dictionary<string, App>();
        
        foreach (KeyValuePair<string, App> app in appRepository) {
            //Debug.Log("searching " + searchTerms);

            Debug.Log(app.Key.IndexOf(searchTerms));
            if (app.Key.IndexOf(searchTerms, System.StringComparison.OrdinalIgnoreCase) >= 0) {
                //Debug.Log("found" + searchTerms);
                searchResults.Add(app.Key, app.Value);
            }
        }

        return searchResults;
    }

    public static void InitiateCategoryOptions(GameObject dropdown) {
        string filePath = Path.Combine(Application.streamingAssetsPath, "Categories.txt");

        StreamReader file = new StreamReader(filePath);
        List<string> categories = new List<string>();

        while(!file.EndOfStream) {
            categories.Add(file.ReadLine());
        }

        TMP_Dropdown m_Dropdown = dropdown.GetComponentInChildren<TMP_Dropdown>();
        m_Dropdown.ClearOptions();
        
        m_Dropdown.AddOptions(categories);
    }

    public static void InitiateCategoryMenu(GameObject prefab, GameObject parent, GameObject dropdown) {
        int categoryIndex = dropdown.GetComponentInChildren<TMP_Dropdown>().value;
        string category = dropdown.GetComponentInChildren<TMP_Dropdown>().options[categoryIndex].text;
        Dictionary<string, App> apps = new Dictionary<string, App>();

        foreach(KeyValuePair<string, App> app in appRepository) {
            string appCat = app.Value.GetCategory().Trim();
            if(appCat.Equals(category)) {
                apps.Add(app.Key, app.Value);
            }
        }

        DeleteAppButton(parent, apps);

        if (prefab != null && parent != null) {
                foreach (KeyValuePair<string, App> app in apps) {
                    if(CheckAppButtonExist(parent, app)) {
                        continue;
                    }

                    GameObject AppButton = Instantiate(prefab, parent.GetComponent<Transform>());
                    AppButton.GetComponent<AppObject>().SetAppInfo(app.Value); 
                    TextMeshProUGUI  ButtonText = AppButton.GetComponentInChildren<TextMeshProUGUI>();
                    if(ButtonText != null) {
                        ButtonText.text = AppButton.GetComponent<AppObject>().GetAppInfo().GetName();
                    }
                }
            }
    }
}
