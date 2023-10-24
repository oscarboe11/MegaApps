using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moderator : User {
    private bool isMod;

    public Moderator(string username, string password) : User(username, password) {
        isMod = true;
    }

    public bool isModerator() {
        return isMod;
    }
    public void deleteComment() {
        // delete comment
    }
}