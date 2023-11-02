using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppObject : MonoBehaviour
{
    private App thisApp;

    public void OnButtonClick() {
        GameObject uimanager = this.transform.parent.parent.parent.parent.Find("UIManager").gameObject;
        uimanager.GetComponent<UIManager>().ViewApp(this);
    }

    public void SetAppInfo (App app) {
        thisApp = new App(app);
    }

    public App GetAppInfo() {
        return thisApp;
    }
}
