using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User {
    private string username;
    private string password;
    private bool loggedIn;
    private List<App> wishlist;

    public User() {
        username = "";
        password = "";
        loggedIn = false;
    }

    public User(string username, string password) {
        this.username = username;
        this.password = password;
        loggedIn = true;
        wishlist = new List<App>();
    }

    public string getUsername() {
        return username;
    }

    public string getPassword() {
        return password;
    }

    public void comment() {
        // make comment
    }
}
