using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.IO;

// tests for app repository
public class AppReposTest {
    private string filePath = Path.Combine(Application.streamingAssetsPath, "Apps.txt");
    List<string> testAppInfo =  new List<string> {
        "Hello Worlds",
        "This app is used for test.",
        "Mega Apps",
        "Desktop",
        "1.0.0",
        "Test",
        "http://www.MegaApp.com",
        "Free",
    };
    // tests constructor
    [Test]
    public void AppReposConstructorTest() {
        AppRepository appRepository = new AppRepository();
        Assert.IsNotNull(appRepository);
    }

    // tests app repository getters
    [Test]
    public void AppReposGetterTest() {
        AppRepository appRepository = new AppRepository();
        Assert.AreEqual(appRepository.GetApps().Count, 21);
        Assert.True(appRepository.GetApps().TryGetValue(" Your Music", out App app1));
        Assert.False(appRepository.GetApps().TryGetValue(" Hello World", out App app2));
    }

    // tests adding apps to repository
    [Test]
    public void AppReposAddAppTest() {
        AppRepository appRepository = new AppRepository();
        List<string> testAppInfo =  new List<string> {
            "Hello Worlds",
            "This app is used for test.",
            "Mega Apps",
            "Desktop",
            "1.0.0",
            "Test",
            "http://www.MegaApp.com",
            "Free",
        };
        App testApp = new App(testAppInfo);
        appRepository.AddApp(testApp);
        Assert.True(appRepository.GetApps().TryGetValue("Hello Worlds", out App app1));
        Assert.True(app1.GetCategory().Equals(testAppInfo[5]));
    }

    // tests getting app info from app object(button)
    [Test]
    public void GetAppInfoTest() {
        AppObject appObject = new();
        App app = new App(testAppInfo);
        appObject.SetAppInfo(app);

        Assert.True(app.GetName().Equals(appObject.GetAppInfo().GetName()));
    }
}
