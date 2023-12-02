using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;


public class EventsTest {
    // tests loading categories from file
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

    // tests search function
    [Test]
    public void searchTest() {
        Dictionary<string, App> results = Events.SearchAppRepository("Your Music");

        Assert.True(results.ContainsKey("Your Music"));
    }
}