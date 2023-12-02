using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// handles deleting of comments and delete button on comments
public class CommentApp : MonoBehaviour {
    public Button deleteButton;
    public string commentText;
    public string appName;

    //called to initalize the comment delete functionality
    public void Start() {
        Initialize();
    }
    public void Initialize() {   
        commentText = this.GetComponentInChildren<TextMeshProUGUI>().text.Trim();
        appName = transform.parent.parent.GetComponentInChildren<TextMeshProUGUI>().text.Trim();
        deleteButton.onClick.AddListener(DeleteComment);
    }

    // handles comment deletion processes
    private void DeleteComment() {
        DeleteFromFile();
        
        Destroy(gameObject);
    }

    // removes comment from contents to be written to file
    private void DeleteFromFile() {
        string filePath = Path.Combine(Application.streamingAssetsPath, "Comments.txt");
        string[] lines = File.ReadAllLines(filePath);
        List<string> result = new List<string>();
        Debug.Log(commentText);
        
        string current = "";
        foreach(string line in lines) {
            string[] subs = line.Trim().Split(":");

            string currentName = subs[0].Trim();
            string currentText = subs[1].Trim();

            if (currentName == "Name") {
                current = currentText;
            }

            if (!(string.Equals(current, appName, StringComparison.OrdinalIgnoreCase) && string.Equals(currentText, commentText, StringComparison.OrdinalIgnoreCase))) {
                result.Add(line);
            }
        }

        File.WriteAllLines(filePath, result.ToArray());
    }
}
