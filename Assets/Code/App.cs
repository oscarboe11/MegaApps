using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App {
    private string name;
    private string description:
    private string category;
    private string platform;
    private string version;
    private string organization;
    private string link;
    private float price;
    public List<string> comments;  

    // getters
    public string getName() {
        return name;
    }

    public string getDescription() {
        return description;
    }

    public string getCategory() {
        return category;
    }

    public string getPlatform() {
        return platform;
    }

    public string getVersion() {
        return version;
    }

    public string getOrganization() {
        return organization;
    }

    public string getLink() {
        return link;
    }
    
    public float getPrice() {
        return price;
    }

    // setters
        public void setName(string name) {
        this.name = name; 
    }

    public void setDescription(string description) {
        this.description = description;
    }

    public void setCategory(string category) {
        this.category = category;
    }

    public void setPlatform(string version) {
        this.platform = platform;
    }

    public void setVersion(string version) {
        this.version = version;
    }

    public void getOrganization(string organization) {
        this.organization organization;
    }

    public void setLink() {
        this.link = link;
    }
    
    public void setPrice() {
        this.price = price;
    }
}