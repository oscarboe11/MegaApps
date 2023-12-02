using System.Collections.Generic;
using NUnit.Framework;

public class UserTest {
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

    // tests user constructor
    [Test]
    public void constructorTest() {
        User u1 = new User("oscar", "password");
        Assert.True(u1.getUsername().Equals("oscar"));
        Assert.True(u1.getPassword().Equals("password"));
    }
} 
