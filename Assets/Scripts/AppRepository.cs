using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppRepository
{
    // private FileStream file = new FileStream("Apps.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
    // private StreamReader file = new StreamReader(@"Assets\Scripts\Apps.txt");
    private string filePath = Path.Combine(Application.streamingAssetsPath, "Apps.txt");
    private Dictionary<string, App> repository = new Dictionary<string, App>();

    public AppRepository() {
        StreamReader file = new StreamReader(filePath);
        List<string> appInfo = new List<string>();
        string[] line;
        while(!file.EndOfStream) {
            line = file.ReadLine().Split(':');
            if(line.Length > 1) {
                appInfo.Add(line[1]);
                // Debug.Log(line[1]);
                if(line[0] == "Price") {
                    App app = new App(appInfo);
                    repository.Add(appInfo[0], app);
                    appInfo.Clear();
                }
            }
        }
    }

    public Dictionary<string, App> GetApps() { 
        return this.repository;
    }

    public void SetApp() {}

    public void AddApp() {}
}
