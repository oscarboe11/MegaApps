using System.Collections;
using System.Collections.Generic;
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

    private static void DeleteAppButton(GameObject parent, Dictionary<string, App> searchApp) {
        Transform parentTransform = parent.transform;
        if(parentTransform.childCount > 0) {
            for (int i = 0; i < parentTransform.childCount; i++) {
                // Access each child using the GetChild method
                GameObject child = parentTransform.GetChild(i).gameObject;
                if(!searchApp.ContainsKey(child.GetComponent<AppObject>().GetAppInfo().GetName())) {
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
                if(app.Value.GetName() == child.GetComponent<AppObject>().GetAppInfo().GetName()) {
                    isExist = true;
                }
            }
        }
        return isExist;
    } 

    // public static void SearchApps(string searchTerms) {
    //     Dictionary<string, App> searchResults = SearchAppRepository(searchTerms);

    //     // foreach (KeyValuePair<string, App> app in searchResults) {
    //     //     Debug.Log(app.Key);
    //     // }
    // }

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
}
