using UnityEngine;

// Class for user and managing user permissions
// admin can aprove app requests and delete comments
// moderator can delete comments
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
