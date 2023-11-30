using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class AddWishListTest
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

    // A Test behaves as an ordinary method
    [Test]
    public void TestAddToWishList() {
        User testU = new User("tester", "12345");
        App testA = new App(testAppInfo);

        testU.addToWishList(testA);
        Assert.True(testU.getWishList().Contains(testA));
    }
}
