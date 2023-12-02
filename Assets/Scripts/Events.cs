using System.IO;
using System.Text;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// holds functions that are called by events manager on startup
// and during general use
public class Events : MonoBehaviour {
    private static AppRepository AppData = new AppRepository();
    private static Dictionary<string, App> appRepository = AppData.GetApps();
    private static Dictionary<string, App> pendingAppRepository = AppData.GetPendingApps();
    public GameObject searchBar;

    // sets up and displays main menu
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

    // updates the displayed apps on main menu
    public static void UpdateMainMenu(GameObject prefab, GameObject parent) {
        for (int i = 0; i < parent.transform.childCount; i++) {
            Destroy(parent.transform.GetChild(i).gameObject);
        }
        InitiateMenu(prefab, parent);
    }

    // displays the store page for an app
    public static void InitiateAppPage(GameObject AppPage, AppObject appObject, GameObject CommentPrefab) {
        App app = appObject.GetAppInfo();
        GameObject Info = AppPage.transform.Find("Viewport").Find("Content").Find("Info").gameObject;
        GameObject gameObject = Info.transform.Find("Name").gameObject;
        gameObject.GetComponent<TextMeshProUGUI>().text = app.GetName();

        gameObject = Info.transform.Find("Description").gameObject;
        gameObject.GetComponent<TextMeshProUGUI>().text = "Description: " + app.GetDescription();

        gameObject = Info.transform.Find("Organization").gameObject;
        gameObject.GetComponent<TextMeshProUGUI>().text = "Organization: " + app.GetOrganization();

        gameObject = Info.transform.Find("Platform").gameObject;
        gameObject.GetComponent<TextMeshProUGUI>().text = "Description: " + app.GetPlatform();

        gameObject = Info.transform.Find("Version").gameObject;
        gameObject.GetComponent<TextMeshProUGUI>().text = "Version: " + app.GetVersion();
        //Debug.Log(app.GetVersion());

        gameObject = Info.transform.Find("Category").gameObject;
        gameObject.GetComponent<TextMeshProUGUI>().text = "Category: " + app.GetCategory();

        gameObject = Info.transform.Find("Link").gameObject;
        gameObject.GetComponent<TextMeshProUGUI>().text = "Link: " + app.GetLink();

        gameObject = Info.transform.Find("Price").gameObject;
        gameObject.GetComponent<TextMeshProUGUI>().text = "Price: " + app.GetPrice();

        gameObject = Info.transform.Find("Comments").gameObject;
        DeleteComment(AppPage);
        InitiateComment(AppPage, CommentPrefab);
    }

    // searches and displays results
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

    // Handles the deletion of app button in gui
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

    // checks if an app button already exists for an app
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

    // searches app repository for given search terms
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

    // handles creating comment from user input
    public static void WriteComment(GameObject AppPage, GameObject CommentInputField, GameObject CommentPrefab) {
        GameObject AppName = AppPage.transform.Find("Viewport").Find("Content").Find("Info").Find("Name").gameObject;
        string name = AppName.GetComponent<TextMeshProUGUI>().text;
        // name = name.Substring(1, name.Length - 1);
        // Debug.Log(AppName);
        string comment = CommentInputField.GetComponentInChildren<TextMeshProUGUI>().text;
        string filePath = Path.Combine(Application.streamingAssetsPath, "Comments.txt");
        string[] lines = File.ReadAllLines(filePath);
        string[] newlines = new string[lines.Length + 1];
        int j = 0;
        for(int i = 0; i < lines.Length; i++) {
            newlines[j] = lines[i];
            j++;
            if(lines[i].Split().Length > 2) {
                string thisName = lines[i].Split(':')[1];
                if(thisName == name) {
                    // Debug.Log("I found at" + i);
                    newlines[j] = "Comment: " + comment;
                    j++;
                }
            }
        }
        File.WriteAllLines(filePath, newlines, Encoding.UTF8);
        UpdateComment(AppPage, CommentPrefab);
        CommentInputField.GetComponentInChildren<TextMeshProUGUI>().text = " ";
        // Debug.Log("Write Done");
    }

    // loads comments from file
    private static void InitiateComment(GameObject AppPage, GameObject CommentPrefab) {
        GameObject AppInfo = AppPage.transform.Find("Viewport").Find("Content").Find("Info").gameObject;
        string name = AppInfo.transform.Find("Name").GetComponent<TextMeshProUGUI>().text;
        GameObject Comments = AppInfo.transform.Find("Comments").gameObject;
        string comment = "";
        string filePath = Path.Combine(Application.streamingAssetsPath, "Comments.txt");
        string[] lines = File.ReadAllLines(filePath);
        for(int i = 0; i < lines.Length; i++) {
            if(lines[i].Split().Length > 2) {
                string thisName = lines[i].Split(':')[1];
                if(thisName == name) {
                    for(int j = i+1; j < lines.Length; j++) {
                        if(lines[j].Split(':')[0] == "Comment") {
                            comment = lines[j].Split(':')[1];
                            //Debug.Log(comment);
                            CommentPrefab.GetComponent<TextMeshProUGUI>().text = comment;
                            Instantiate(CommentPrefab, Comments.GetComponent<Transform>());
                        }
                        else {
                            return;
                        }
                    }
                }
            }
        }
        CommentPrefab.GetComponent<TextMeshProUGUI>().text = comment;
        GameObject CommentObject = Instantiate(CommentPrefab, Comments.GetComponent<Transform>());
    }

    // removes comments from view
    private static void DeleteComment(GameObject AppPage) {
        GameObject AppInfo = AppPage.transform.Find("Viewport").Find("Content").Find("Info").gameObject;
        GameObject Comments = AppInfo.transform.Find("Comments").gameObject;
        foreach(Transform child in Comments.transform) {
            if(child.gameObject.name != "Title") {
                Destroy(child.gameObject);
            }
        }
    }

    // handles reloading of comments
    private static void UpdateComment(GameObject AppPage, GameObject CommentPrefab) {
        GameObject AppInfo = AppPage.transform.Find("Viewport").Find("Content").Find("Info").gameObject;
        string name = AppInfo.transform.Find("Name").GetComponent<TextMeshProUGUI>().text;
        GameObject Comments = AppInfo.transform.Find("Comments").gameObject;
        string comment = "";
        string filePath = Path.Combine(Application.streamingAssetsPath, "Comments.txt");
        string[] lines = File.ReadAllLines(filePath);
        for(int i = 0; i < lines.Length; i++) {
            if(lines[i].Split().Length > 2) {
                string thisName = lines[i].Split(':')[1];
                if(thisName == name) {
                    string c = lines[i+1].Split(':')[1];
                    comment = c;
                    // Debug.Log(comment);
                    break;
                }
            }
        }
        CommentPrefab.GetComponent<TextMeshProUGUI>().text = comment;
        Instantiate(CommentPrefab, Comments.GetComponent<Transform>());
        // CommentObject.GetComponent<TextMeshProUGUI>().text = comment;
    }

    // loads category options from file for category dropdown
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

    // loads apps that are of selected categories
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

    // loads apps in pending list
    public static void InitiatePendingList(GameObject prefab, GameObject parent) {
        if (prefab != null && parent != null) {
            foreach (KeyValuePair<string, App> app in pendingAppRepository) {
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

    // removes pending apps from view
    public static void UpdatePendingList(GameObject prefab, GameObject parent) {
        for (int i = 0; i < parent.transform.childCount; i++) {
            Destroy(parent.transform.GetChild(i).gameObject);
        }
        InitiatePendingList(prefab, parent);
    }

    // displays pending apps
    public static void InitiatePendingAppPage(GameObject AppPage, AppObject appObject) {
        App app = appObject.GetAppInfo();
        GameObject Info = AppPage.transform.Find("Info").gameObject;
        GameObject gameObject = Info.transform.Find("Name").gameObject;
        gameObject.GetComponent<TextMeshProUGUI>().text = app.GetName();

        gameObject = Info.transform.Find("Description").gameObject;
        gameObject.GetComponent<TextMeshProUGUI>().text = "Description: " + app.GetDescription();

        gameObject = Info.transform.Find("Organization").gameObject;
        gameObject.GetComponent<TextMeshProUGUI>().text = "Organization: " + app.GetOrganization();

        gameObject = Info.transform.Find("Platform").gameObject;
        gameObject.GetComponent<TextMeshProUGUI>().text = "Description: " + app.GetPlatform();

        gameObject = Info.transform.Find("Version").gameObject;
        gameObject.GetComponent<TextMeshProUGUI>().text = "Version: " + app.GetVersion();
        //Debug.Log(app.GetVersion());

        gameObject = Info.transform.Find("Category").gameObject;
        gameObject.GetComponent<TextMeshProUGUI>().text = "Category: " + app.GetCategory();

        gameObject = Info.transform.Find("Link").gameObject;
        gameObject.GetComponent<TextMeshProUGUI>().text = "Link: " + app.GetLink();

        gameObject = Info.transform.Find("Price").gameObject;
        gameObject.GetComponent<TextMeshProUGUI>().text = "Price: " + app.GetPrice();
    }

    // handles app requests
    public static void SubmitAppRequest(GameObject AddAppPage) {
        List<string> pendingAppInfo = new List<string>();

        GameObject input = AddAppPage.transform.Find("Name").Find("InputField").Find("Text Area").Find("Input").gameObject;
        string name = input.GetComponent<TextMeshProUGUI>().text;
        pendingAppInfo.Add(name);

        input = AddAppPage.transform.Find("Description").Find("InputField").Find("Text Area").Find("Input").gameObject;
        string description = input.GetComponent<TextMeshProUGUI>().text;
        pendingAppInfo.Add(description);

        input = AddAppPage.transform.Find("Organization").Find("InputField").Find("Text Area").Find("Input").gameObject;
        string organization = input.GetComponent<TextMeshProUGUI>().text;
        pendingAppInfo.Add(organization);
        
        input = AddAppPage.transform.Find("Platform").Find("InputField").Find("Text Area").Find("Input").gameObject;
        string platform = input.GetComponent<TextMeshProUGUI>().text;
        pendingAppInfo.Add(platform);
        
        input = AddAppPage.transform.Find("Version").Find("InputField").Find("Text Area").Find("Input").gameObject;
        string version = input.GetComponent<TextMeshProUGUI>().text;
        pendingAppInfo.Add(version);

        input = AddAppPage.transform.Find("Category").Find("InputField").Find("Text Area").Find("Input").gameObject;
        string category = input.GetComponent<TextMeshProUGUI>().text;
        pendingAppInfo.Add(category);

        input = AddAppPage.transform.Find("Link").Find("InputField").Find("Text Area").Find("Input").gameObject;
        string link = input.GetComponent<TextMeshProUGUI>().text;
        pendingAppInfo.Add(link);

        input = AddAppPage.transform.Find("Price").Find("InputField").Find("Text Area").Find("Input").gameObject;
        string price = input.GetComponent<TextMeshProUGUI>().text;
        pendingAppInfo.Add(price);

        AppData.AddPendingApp(pendingAppInfo);
    }

    // adds app to repository
    public static void ApproveNewApp(GameObject AddAppAdmin) {
        string name = AddAppAdmin.transform.Find("Info").Find("Name").gameObject.GetComponent<TextMeshProUGUI>().text;
        App newApp = pendingAppRepository[name];
        AppData.AddApp(newApp);
        AppData.DeletePendingApp(newApp);
    }

    // rejects app, removes from pending apps list
    public static void RejectNewApp(GameObject AddAppAdmin) {
        string name = AddAppAdmin.transform.Find("Info").Find("Name").gameObject.GetComponent<TextMeshProUGUI>().text;
        App newApp = pendingAppRepository[name];
        AppData.DeletePendingApp(newApp);
    }

    
}
