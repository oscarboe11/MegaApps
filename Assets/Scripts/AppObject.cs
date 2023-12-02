using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AppObject : MonoBehaviour
{
    private App thisApp;

    public void OnButtonClick() {
        GameObject canvas = GameObject.Find("Canvas");
        //Debug.Log(canvas.name);
        GameObject uimanager = canvas.transform.Find("UIManager").gameObject;
        uimanager.GetComponent<UIManager>().ViewApp(this);
    }

    public void OnPendingButtonClick() {
        GameObject user = GameObject.Find("User");
        if(user.GetComponent<User>().GetPermission() == "Admin") {
            GameObject canvas = GameObject.Find("Canvas");
            Debug.Log(canvas.name);
            GameObject uimanager = canvas.transform.Find("UIManager").gameObject;
            uimanager.GetComponent<UIManager>().ViewPendingApp(this);
        }
        else {
            TextMeshProUGUI message = GameObject.Find("AddAppsPageMessage").GetComponent<TextMeshProUGUI>();
            message.text = "You don't have such permission.";
        }
    }

    public void SetAppInfo (App app) {
        thisApp = new App(app);
    }

    public App GetAppInfo() {
        return thisApp;
    }
}
