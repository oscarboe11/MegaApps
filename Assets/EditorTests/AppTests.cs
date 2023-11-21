using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class AppTests
{
    List<string> testAppInfo =  new List<string> {
        "Hello Worlds",
        "This app is used for test.",
        "Test",
        "Desktop",
        "1.0.0",
        "Mega Apps",
        "http://www.MegaApp.com",
        "Free",
    };

    [Test]
    public void AppConstructorTest()
    {
        App testApp = new App(testAppInfo);
        Assert.IsNotNull(testApp);
    }

    [Test]
    public void AppCopyConstructorTest()
    {
        App testApp = new App(testAppInfo);
        App testCopyApp = new App(testApp);
        Assert.True(testApp == testCopyApp);
    }

    [Test]
    public void AppCopyGetterTest()
    {
        App testApp = new App(testAppInfo);
        App testCopyApp = new App(testApp);
        Assert.True(testApp == testCopyApp);
        Assert.AreEqual(testApp.GetName(), testCopyApp.GetName());
        Assert.AreNotEqual(testApp.GetName(), testApp.GetCategory());
        Assert.AreNotEqual(testApp.GetVersion(), testCopyApp.GetDescription());
        Assert.True(testApp.GetPlatform() == "Desktop");
        Assert.False(testApp.GetLink() == "Free");
        Assert.False(testApp.GetPrice() != testApp.GetPrice());
    }

    [Test]
    public void AppCopySetterTest()
    {
        App testApp = new App(testAppInfo);
        App testCopyApp = new App(testApp);
        testApp.SetName("Hello America");
        Assert.True(testApp != testCopyApp);
        testApp.SetVersion("1.0.5");
        Assert.AreNotEqual(testApp.GetVersion(), testCopyApp.GetVersion());
        testApp.SetDescription("This is used for setter test");
        Assert.AreNotEqual("This is used for setter test",  testCopyApp.GetDescription());
        testApp.SetCategory("Music");
        testCopyApp.SetCategory("Music");
        Assert.AreEqual(testApp.GetCategory(), testCopyApp.GetCategory());
        testApp.SetOrganization("asdfasdf");
        testApp.SetPrice("asdfasdf");
        Assert.AreEqual(testApp.GetOrganization(), testApp.GetPrice());
        testCopyApp.SetLink("Hello Worlds");
        Assert.True(testCopyApp.GetLink() == testCopyApp.GetName());

    }
}
