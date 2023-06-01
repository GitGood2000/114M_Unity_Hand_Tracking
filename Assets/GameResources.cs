using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResources : MonoBehaviour

{
    private static GameResources _i;

    public TextAsset JSONFile;

    private static bool isOk = false;
    public static GameResources i
    {
        get
        {
            if (_i == null) _i = Instantiate(Resources.Load("GameResources") as GameObject).GetComponent<GameResources>();
            return _i;
        }
    }
    public static void SetOk(bool set)
    {
        isOk = set;
    }

    public static bool GetOk()
    {
        return isOk;
    }
}
