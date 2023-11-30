using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.IO;

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

    [Test]
    public void wishListTest() {
        User u = new User();
        App app = new App(testAppInfo);
        u.addToWishList(app);
        Assert.True(u.getWishList().Contains(app));
    }

    [Test]
    public void constructorTest() {
        User u1 = new User("oscar", "password");
        Assert.True(u1.getUsername().Equals("oscar"));
        Assert.True(u1.getPassword().Equals("password"));
    }
} 
