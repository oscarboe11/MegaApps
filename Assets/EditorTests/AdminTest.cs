using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.IO;

public class AdminTest {
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

    [Test]
    public void testAddApp() {
        App app = new App(testAppInfo);
        AppRepository appRepository = new AppRepository();
        appRepository.AddApp(app);
        Assert.True(appRepository.GetApps().ContainsKey("Hello Worlds"));
    }
}