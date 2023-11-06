using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Events : MonoBehaviour
{
    private static Dictionary<string, App> appRepository = new AppRepository().GetApps();
    
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

    public static void SearchApps(string searchTerms) {
        
    }
}
