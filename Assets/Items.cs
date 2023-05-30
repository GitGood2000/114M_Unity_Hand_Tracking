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

    public void UpdateJsonInstallNum(string id, int installNum)
    {
        SetPathsJ();
        string jsonString = File.ReadAllText(path);
        JObject jObject = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString) as JObject;
        JToken jToken = jObject.SelectToken($"items.{id}.install_number");
        jToken.Replace(installNum);
        SaveData(jObject);
    }

    public int GetInstallNum(string id)
    {
        SetPathsJ();
        string jsonString = File.ReadAllText(path);
        JObject jObject = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString) as JObject;
        int installNum=jObject["items"][id]["install_number"].Value<int>();
        return installNum;

    }

    public int GetRightInstallNum(string id)
    {
        SetPathsJ();
        string jsonString = File.ReadAllText(path);
        JObject jObject = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString) as JObject;
        int rightInstallNum=jObject["items"][id]["right_install_number"].Value<int>();
        return rightInstallNum;

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
