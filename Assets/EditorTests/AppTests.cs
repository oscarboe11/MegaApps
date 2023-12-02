using System.Collections.Generic;
using NUnit.Framework;

// holds tests for app class
public class AppTests
{
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

    // tests app constructor
    [Test]
    public void AppConstructorTest()
    {
        App testApp = new App(testAppInfo);
        Assert.IsNotNull(testApp);
    }

    // tests app copy constructor
    [Test]
    public void AppCopyConstructorTest()
    {
        App testApp = new App(testAppInfo);
        App testCopyApp = new App(testApp);
        Assert.True(testApp.GetName() == testCopyApp.GetName());
    }

    // tests app getters after using copy constructors
    [Test]
    public void AppCopyGetterTest()
    {
        App testApp = new App(testAppInfo);
        App testCopyApp = new App(testApp);
        Assert.AreEqual(testApp.GetName(), testCopyApp.GetName());
        Assert.AreNotEqual(testApp.GetName(), testApp.GetCategory());
        Assert.AreNotEqual(testApp.GetVersion(), testCopyApp.GetDescription());
        Assert.True(testApp.GetPlatform() == "Desktop");
        Assert.False(testApp.GetLink() == "Free");
        Assert.False(testApp.GetPrice() != testApp.GetPrice());
    }

    // tests setters after using copy constructors
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
