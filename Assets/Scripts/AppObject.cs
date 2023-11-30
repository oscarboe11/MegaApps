using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppObject : MonoBehaviour
{
    private App thisApp;

    public void OnButtonClick() {
        GameObject canvas = GameObject.Find("Canvas");
        Debug.Log(canvas.name);
        GameObject uimanager = canvas.transform.Find("UIManager").gameObject;
        uimanager.GetComponent<UIManager>().ViewApp(this);
    }

    public void OnPendingButtonClick() {
        GameObject canvas = GameObject.Find("Canvas");
        Debug.Log(canvas.name);
        GameObject uimanager = canvas.transform.Find("UIManager").gameObject;
        uimanager.GetComponent<UIManager>().ViewPendingApp(this);
    }

    public void SetAppInfo (App app) {
        thisApp = new App(app);
    }

    public App GetAppInfo() {
        return thisApp;
    }
}
