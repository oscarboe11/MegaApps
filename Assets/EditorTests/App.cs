using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App {
    private string name;
    private string description;
    private string category;
    private string platform;
    private string version;
    private string organization;
    private string link;
    private string price;
    public List<string> comments;  

    public App(List<string> appInfo) {
        name = appInfo[0];
        description = appInfo[1];
        category = appInfo[5];
        platform = appInfo[3];
        version = appInfo[4];
        organization = appInfo[2];
        link = appInfo[6];
        price = appInfo[7];
        comments = new List<string>();
    }

    public App(App app) {
        this.name = app.GetName();
        this.description = app.GetDescription();
        this.category = app.GetCategory();
        this.platform = app.GetPlatform();
        this.version = app.GetVersion();
        this.organization = app.GetOrganization();
        this.link = app.GetLink();
        this.price = app.GetPrice();
        this.comments = app.GetComments();
    }
    
    public string GetName() {
        return name;
    }

    public string GetDescription() {
        return description;
    }

    public string GetCategory() {
        return category;
    }

    public string GetPlatform() {
        return platform;
    }

    public string GetVersion() {
        return version;
    }

    public string GetOrganization() {
        return organization;
    }

    public string GetLink() {
        return link;
    }
    
    public string GetPrice() {
        return price;
    }

    public List<string> GetComments() {
        return comments;
    }

    // setters
    public void SetName(string name) {
        this.name = name; 
    }

    public void SetDescription(string description) {
        this.description = description;
    }

    public void SetCategory(string category) {
        this.category = category;
    }

    public void SetPlatform(string platform) {
        this.platform = platform;
    }

    public void SetVersion(string version) {
        this.version = version;
    }

    public void SetOrganization(string organization) {
        this.organization = organization;
    }

    public void SetLink(string link) {
        this.link = link;
    }
    
    public void SetPrice(string price) {
        this.price = price;
    }

    public static bool operator ==(App left, App right) {
        return left.GetName() == right.GetName() &&
               left.GetDescription() == right.GetDescription() &&
               left.GetCategory() == right.GetCategory() &&
               left.GetPlatform() == right.GetPlatform() &&
               left.GetVersion() == right.GetVersion() &&
               left.GetOrganization() == right.GetOrganization() &&
               left.GetLink() == right.GetLink() &&
               left.GetPrice() == right.GetPrice() &&
               left.GetComments() == right.GetComments();

    }

    public static bool operator !=(App left, App right) {
        return !(left == right);
    }
}