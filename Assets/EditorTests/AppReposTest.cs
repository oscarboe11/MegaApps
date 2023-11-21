using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.IO;

public class AppReposTest
{
    private string filePath = Path.Combine(Application.streamingAssetsPath, "Apps.txt");
    [Test]
    public void AppReposConstructorTest()
    {
        AppRepository appRepository = new AppRepository();
        Assert.IsNotNull(appRepository);
    }

    [Test]
    public void AppReposGetterTest()
    {
        AppRepository appRepository = new AppRepository();
        Assert.AreEqual(appRepository.GetApps().Count, 20);
        Assert.True(appRepository.GetApps().TryGetValue(" Your Music", out App app1));
        Assert.False(appRepository.GetApps().TryGetValue(" Hello World", out App app2));
    }

    [Test]
    public void AppReposAddAppTest()
    {
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
        Assert.AreEqual(app1.GetCategory(), testAppInfo[5]);
    }
}
