using System.IO;
using UnityEngine;
using System;

public class DataManager : MonoBehaviour
{
    #region Visual Studios Public
    public string SaveFolderName = "Saves";
    public string PlayerName = "Player1";
    public string SaveFileExtention = "WisllyAdventureSave";
    public bool StartSaveSys = true;
    public bool StartAtLoad = false;

    public Item[] Objects;
    public PlayerHealth Health;
    public GameObject PlayerGameObject;
    #endregion

    #region Visual Studios Private
    private string GameFolder;
    private string SaveFolder;
    private string SaveFile;
    #endregion

    void Start()
    {
        StartSaveSys = true;

        GameFolder = Directory.GetCurrentDirectory();
        SaveFolder = Path.Combine(GameFolder, SaveFolderName);
        SaveFile = PlayerName + "." + SaveFileExtention;

        if (!File.Exists(SaveFolder)) Directory.CreateDirectory(SaveFolderName);

        SaveFile = Path.Combine(SaveFolder, SaveFile);

        if (!File.Exists(SaveFile)) File.Create(SaveFile).Close();
        StartSaveSys = false;

        SaveData("1234", "Test");
    }

    public string ReadData()
    {
        return File.ReadAllText(SaveFile);
    }

    public void DeleteSaveFile()
    {
        File.Delete(SaveFile);
    }

    public void DeleteSaveByKey(string DataKey)
    {
        string[] DataSaved = ReadData().Split('\n');

        string NewData = "";
        bool KeyFound = false;

        foreach (string Data in DataSaved)
        {
            if (Data.Split('=')[0] == DataKey)
            {
                KeyFound = true;
            }
            else
            {
                if (Data != "")
                {
                    NewData += Data + "\n";
                }
            }
        }

        if (!KeyFound)
        {
            Debug.LogError("Key Not Found");
        }

        File.WriteAllText(SaveFile, NewData);
    }

    public void SaveData(string DataToSave, string DataKey)
    {
        string[] DataSaved = ReadData().Split('\n');

        string NewData = "";
        bool KeyFound = false;

        foreach (string Data in DataSaved)
        {
            if (Data.Split('=')[0] == DataKey)
            {
                NewData += DataKey + "=" + DataToSave + "\n";
                KeyFound = true;
            }
            else
            {
                if (Data != "")
                {
                    NewData += Data + "\n";
                }
            }
        }

        if (!KeyFound)
        {
            NewData += DataKey + "=" + DataToSave + "\n";
        }

        File.WriteAllText(SaveFile, NewData);
    }

    public string LoadString(string DataKey)
    {
        string[] DataSaved = ReadData().Split('\n');

        foreach (string Data in DataSaved)
        {
            if (Data.Split('=')[0] == DataKey)
            {
                return Data.Split('=')[1];
            }
        }
        Debug.LogError("Key Not Found");
        return "null";
    }

    public float LoadFloat(string DataKey)
    {
        string[] DataSaved = ReadData().Split('\n');

        foreach (string Data in DataSaved)
        {
            if (Data.Split('=')[0] == DataKey)
            {
                return Convert.ToSingle(Data.Split('=')[1]);
            }
        }
        Debug.LogError("Key Not Found");
        return 0f;
    }

    public int LoadInt(string DataKey)
    {
        string[] DataSaved = ReadData().Split('\n');

        foreach (string Data in DataSaved)
        {
            if (Data.Split('=')[0] == DataKey)
            {
                return Convert.ToInt32(Data.Split('=')[1]);
            }
        }
        Debug.LogError("Key Not Found");
        return 0;
    }

    public bool LoadBool(string DataKey)
    {
        string[] DataSaved = ReadData().Split('\n');

        foreach (string Data in DataSaved)
        {
            if (Data.Split('=')[0] == DataKey)
            {
                return Convert.ToBoolean(Data.Split('=')[1]);
            }
        }
        Debug.LogError("Key Not Found");
        return false;
    }

}