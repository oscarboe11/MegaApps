using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;

public class User : MonoBehaviour {
    private string username;
    private string password;
    private string permission = "";
    private bool loggedIn;
    private List<App> wishlist;
    
    public User() {
        this.username = "";
        this.password = "";
        this.loggedIn = false;
    }

    public User(string username, string password) {
        this.username = username;
        this.password = password;
        this.loggedIn = true;
        this.wishlist = new List<App>();
    }

    public string getUsername() {
        return username;
    }

    public string getPassword() {
        return password;
    }

    public bool isLoggedIn() {
        return loggedIn;
    }

    public void SetPermission(string permission) {
        Debug.Log(permission);
        PlayfabManager playfabManager = GetComponent<PlayfabManager>();
        if(permission == "Admin") {
            this.permission = permission;
            playfabManager.SetAdminPermission();
        }
        else if(permission == "Moderator") {
            this.permission = permission;
            playfabManager.SetModPermission();
        }
        else {
            this.permission = "User";
            playfabManager.SetUserPermission();
        }
    }

    public string GetPermission() {
        return permission;
    }

    public List<App> getWishList() {
        return wishlist;
    }
}
