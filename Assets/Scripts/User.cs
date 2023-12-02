using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour {
    private string permission = "";

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
}
