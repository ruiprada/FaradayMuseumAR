using System;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

public sealed class UsabilityTestsSingleton{

    public List<EventData> gameEventsLocal = new List<EventData>();
    public List<EventData> gameEventsServer = new List<EventData>();

    public List<DateTime> GameEvents { get; set; }

    private static UsabilityTestsSingleton _instance = null;

    private bool LOG = false;

    private UsabilityTestsSingleton()
    {

    }

    public static UsabilityTestsSingleton Instance()
    {
        if (_instance == null){

            _instance = new UsabilityTestsSingleton();
        }
        return _instance;
    }

    public void AddGameEvent(LogEventType eventType)
    {
        gameEventsLocal.Add(new EventData(eventType, DateTime.Now));
        gameEventsServer.Add(new EventData(eventType, DateTime.Now));

        SaveOnMobile(); 
    }

    public void AddGameEvent(LogEventType eventType, string objectName)
    {
        gameEventsLocal.Add(new EventData(eventType, objectName, DateTime.Now));
        gameEventsServer.Add(new EventData(eventType, objectName, DateTime.Now));

        SaveOnMobile();
    }

    void OutputTime()
    {
        Debug.Log(Time.time);
    }

    public void SendtoSigma()
    {
        try
        {

        string filename = DateTime.Now.ToString("yyyy-MM-dd") +  ".json";
        string file = JsonConvert.SerializeObject(gameEventsServer, new JsonSerializerSettings() { DateFormatString = "dd/MM/yyyy HH:MM:ss" });

        string urlAddress = "http://web.tecnico.ulisboa.pt/ist172700/Faraday/FileReceiver.php?filename=" + filename + "&file=" + file;
           
        HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(urlAddress);
        Credential credential = LoadJson("credentials");
        NetworkCredential myCredentials = new NetworkCredential(credential.username, credential.password);

        webRequest.Method = "GET";

        webRequest.Credentials = CredentialCache.DefaultCredentials;

        var webResponse = webRequest.GetResponse();

            /*
            var webResponse = (HttpWebResponse)await Task.Factory.FromAsync(webRequest.BeginGetResponse,
                        webRequest.EndGetResponse,
                        null);
            */

        var webStream = webResponse.GetResponseStream();
        var responseReader = new StreamReader(webStream);
        var response = responseReader.ReadToEnd();
        Console.WriteLine("Response: " + response);
        responseReader.Close();

        gameEventsServer.Clear();

        }catch{
            Debug.LogWarning("Communication Failure");
        }
    }

    public void SaveOnMobile()
    {
        if (!LOG)
        {
            return;
        }

        string filePath = Application.persistentDataPath + "/" + DateTime.Now.ToString("yyyy-MM-dd") + ".json";
        string fileData = JsonConvert.SerializeObject(gameEventsLocal, new JsonSerializerSettings() { DateFormatString = "dd/MM/yyyy HH:MM:ss" });

        try
        {
            File.AppendAllText(filePath, fileData);

            gameEventsLocal.Clear();
        }
        catch
        {
            Debug.LogWarning("Local Save Failure");
        }
    }

    public Credential LoadJson(string path)
    {
        using (StreamReader r = new StreamReader("Assets/Server/" + path + ".json"))
        {
            string json = r.ReadToEnd();
            Credential credential = JsonUtility.FromJson<Credential>(json);
            return credential;
        }
    }
}


public class Credential
{
    public string username;
    public string password;

}