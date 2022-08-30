using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    private void Start()
    {
        instance = this;
    }
    public int SaveSlot;
    public string UserName;
    public string CurrentLocal;
    public string GameTime;
    public GameData CurGameData;

    public bool CreateDatas() {
        try
        {
            CurGameData.playerData.SetValues();
            return true;
        }
        catch (Exception e) { 
        return false;
        }
    }

    public bool SaveInJson()
    {
        try
        {

            if (SaveSlot >= 3)
            {
                return false;
            }
            else
            {
                string GameSave = JsonUtility.ToJson(CurGameData);
                System.IO.File.WriteAllText(Application.persistentDataPath + "/Saves/" + UserName + "-" + SaveSlot, GameSave);
                return true;
            }
        }
        catch (Exception E)
        {
            CurGameData = null;
            return false;
        }
    }
    public List<GameData> LoadAllSlots()
    {
        List<GameData> list = new List<GameData>();
        for (int i = 0; i >= 3; i++)
        {
            if (File.Exists(Application.persistentDataPath + "/Saves/" + UserName + "-" + i))
            {
                string FileContent = File.ReadAllText(Application.persistentDataPath + "/Saves/" + UserName + "-" + i);
                list.Add(JsonUtility.FromJson<GameData>(FileContent));
            }

        }
        return list;
    }
    public GameData LoadInJson()
    {
        if (File.Exists(Application.persistentDataPath + "/Saves/" + UserName + "-" + SaveSlot))
        {
            string FileContent = File.ReadAllText(Application.persistentDataPath + "/Saves/" + UserName + "-" + SaveSlot);
            return JsonUtility.FromJson<GameData>(FileContent);

        }
        return null;
    }

    private void Initialize()
    {

    }
}
