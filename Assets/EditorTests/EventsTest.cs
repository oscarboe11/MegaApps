using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.IO;

public class EventsTest {
    [Test]
    public void loadCategoriesTest() {
        List<string> results = Events.InitiateCategoryOptions(new GameObject());
        List<string> categories = new List<string> {"Music",
            "Weather",
            "Health & Fitness",
            "Photography",
            "Food & Drink",
            "Finance",
            "Travel",
            "News",
            "Education",
            "Games",
            "Productivity",
            "Books",
            "Entertainment",
            "Lifestyle"};
        Assert.AreEqual(results, categories);
    }

    [Test]
    public void searchTest() {
        AppRepository appRepository = new AppRepository();
        Dictionary<string, App> results = Events.SearchAppRepository("Music");

        Assert.AreEqual(results, "Your Music");
    }
}