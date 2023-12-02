using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

// this class loads and stores all apps in a Dictionary<string, App>
public class AppRepository {
    // private FileStream file = new FileStream("Apps.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
    // private StreamReader file = new StreamReader(@"Assets\Scripts\Apps.txt");
    private string filePath = Path.Combine(Application.streamingAssetsPath, "Apps.txt");
    private string pendingFilePath = Path.Combine(Application.streamingAssetsPath, "PendingList.txt");
    private Dictionary<string, App> repository = new Dictionary<string, App>();
    private Dictionary<string, App> pendingRepository = new Dictionary<string, App>();

    // constructor
    public AppRepository() {
        StreamReader file = new StreamReader(filePath);
        List<string> appInfo = new List<string>();
        string[] line;
        while(!file.EndOfStream) {
            line = file.ReadLine().Split(':');
            if(line.Length > 1) {
                appInfo.Add(line[1]);
                //Debug.Log(line[1]);
                if(line[0] == "Price") {
                    App app = new App(appInfo);
                    repository.Add(appInfo[0], app);
                    appInfo.Clear();
                }
            }
        }
        file.Close();

        StreamReader pendingFile = new StreamReader(pendingFilePath);
        List<string> pendingAppInfo = new List<string>();
        string[] pendingLine;
        while(!pendingFile.EndOfStream) {
            pendingLine = pendingFile.ReadLine().Split(':');
            if(pendingLine.Length > 1) {
                pendingAppInfo.Add(pendingLine[1]);
                if(pendingLine[0] == "Price") {
                    App app = new App(pendingAppInfo);
                    pendingRepository.Add(pendingAppInfo[0], app);
                    pendingAppInfo.Clear();
                }
            }
        }
        pendingFile.Close();
    }

    // getters
    public Dictionary<string, App> GetApps() { 
        return this.repository;
    }

    public Dictionary<string, App> GetPendingApps() { 
        return this.pendingRepository;
    }

    // adds app to repository and writes to file
    public void AddApp(App newApp) {
        repository.Add(newApp.GetName(), newApp);
        StreamWriter writer = new StreamWriter(filePath, true);
        // try {
        //     writer.WriteLine();
        //     writer.WriteLine("Name: " + newApp.GetName());
        //     writer.WriteLine("Description: " + newApp.GetDescription());
        //     writer.WriteLine("Organization: " + newApp.GetOrganization());
        //     writer.WriteLine("Platform: " + newApp.GetPlatform());
        //     writer.WriteLine("Version: " + newApp.GetVersion());
        //     writer.WriteLine("Category: " + newApp.GetCategory());
        //     writer.WriteLine("Link: " + newApp.GetLink());
        //     writer.WriteLine("Price: " + newApp.GetPrice());
        // }
        // catch (IOException ex) {
        //     Debug.Log(ex.Message);
        // }
        // finally {
        //     writer.Close();
        // }
    }

    // deletes pending app from file
    public void DeletePendingApp(App newApp) {
        pendingRepository.Remove(newApp.GetName());
        string[] lines = File.ReadAllLines(pendingFilePath);
        List<string> newlines = new List<string>();
        Debug.Log(newApp.GetName());
        for(int i = 0; i < lines.Length; i++) {
            Debug.Log(lines[i]);
            if (lines[i] != "" && lines[i].Split(':')[1] == newApp.GetName()) {
                Debug.Log("asdfasdf");
                i += 7;
            }
            else {
                newlines.Add(lines[i]);
            }
        }
        File.WriteAllLines(pendingFilePath, newlines.ToArray(), Encoding.UTF8);
    }

    // writes pending apps to file
    public void AddPendingApp(List<string> appInfo) {
        pendingRepository.Add(appInfo[0], new App(appInfo));
        StreamWriter writer = new StreamWriter(pendingFilePath, true);
        try {
            writer.WriteLine();
            writer.WriteLine("Name: " + appInfo[0]);
            writer.WriteLine("Description: " + appInfo[1]);
            writer.WriteLine("Organization: " + appInfo[2]);
            writer.WriteLine("Platform: " + appInfo[3]);
            writer.WriteLine("Version: " + appInfo[4]);
            writer.WriteLine("Category: " + appInfo[5]);
            writer.WriteLine("Link: " + appInfo[6]);
            writer.WriteLine("Price: " + appInfo[7]);
        }
        catch (IOException ex) {
            Debug.Log(ex.Message);
        }
        finally {
            writer.Close();
        }
    }
}
