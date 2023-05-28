using System.Diagnostics;
using System.IO;
using UnityEngine;
using Newtonsoft.Json.Linq;


public class Items
{

    private string path = "";

    private void SetPathsJ()
    {
        path = "Assets" + Path.AltDirectorySeparatorChar + "items.json";
    }

    private void SaveData(JObject jObject)
    {
        string updatedJsonString = jObject.ToString();
        File.WriteAllText(path, updatedJsonString);
    }


    public void UpdateJsonPlace(string id, bool is_placed)
    {
        SetPathsJ();
        string jsonString = File.ReadAllText(path);
        JObject jObject = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString) as JObject;
        JToken jToken = jObject.SelectToken($"items.{id}.is_placed");
        jToken.Replace(is_placed);
        SaveData(jObject);
    }

    public void UpdateJsonRetries(string id, int retries)
    {
        SetPathsJ();
        string jsonString = File.ReadAllText(path);
        JObject jObject = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString) as JObject;
        JToken jToken = jObject.SelectToken($"items.{id}.retries_to_place");
        jToken.Replace(retries);
        SaveData(jObject);
    }

    public int GetRetries(string id)
    {
        SetPathsJ();
        string jsonString = File.ReadAllText(path);
        JObject jObject = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString) as JObject;
        int retries=jObject["items"][id]["retries_to_place"].Value<int>();
        return retries;

    }

    public bool GetIsPlaced(string id)
    {
        SetPathsJ();
        string jsonString = File.ReadAllText(path);
        JObject jObject = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString) as JObject;
        bool place=jObject["items"][id]["is_placed"].Value<bool>();
        return place;
    }
    
    public string GetName(string id)
    {
        SetPathsJ();
        string jsonString = File.ReadAllText(path);
        JObject jObject = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString) as JObject;
        string name=jObject["items"][id]["name"].Value<string>();
        return name;

    }
    
}
