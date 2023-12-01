using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CommentApp : MonoBehaviour {
    public Button deleteButton;
    public string commentText;
    public string appName;

    public void Start() {
        Initialize();
    }
    public void Initialize() {   
        commentText = this.GetComponentInChildren<TextMeshProUGUI>().text;
        appName = transform.parent.parent.GetComponentInChildren<TextMeshProUGUI>().text;
        deleteButton.onClick.AddListener(DeleteComment);
    }

    private void DeleteComment() {
        DeleteFromFile();
        
        Destroy(gameObject);
    }

    private void DeleteFromFile() {
        string filePath = Path.Combine(Application.streamingAssetsPath, "Comments.txt");
        string[] lines = File.ReadAllLines(filePath);
        List<string> result = new List<string>();
        //string[] subs = lineList[0].Split(":");
        
        string current = "";
        for(int i = 0; i < lines.Length; i++) {
            string line = lines[i];
            string[] subs = line.Split(":");
            
            if(subs[0].Equals("App")) {
                current = subs[1];
            }

            if(!(current.Equals(appName) && subs[1].Equals(commentText))) {
                result.Add(line);
            }
        }

        WriteToFile(result);
    }

    private void WriteToFile(List<string> contents) {
        StreamWriter s = new StreamWriter(Path.Combine(Application.streamingAssetsPath, "Comments.txt"));

        foreach(string line in contents) {
            s.WriteLine(line);
        }
    }
}
