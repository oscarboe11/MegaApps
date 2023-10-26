using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Admin : Moderator {
    private bool isAdmin;

    public Admin(string username, string password) : Moderator(username, password) {
        this.isAdmin = true;
    }

    public bool getAdminState() {
        return isAdmin;
    }
    public void addApp() {
        // add app
    }
}