using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    #region Unity Public
    public DataManager SaveSystem;
    #endregion

    private bool SaveDataAtStart = true;

    public void Update()
    {
        if (SaveSystem.StartAtLoad && SaveDataAtStart)
        {
            SaveAllData();
            SaveDataAtStart = false;
        }
    }

    public void SavePlayerPos()
    {
        SaveSystem.SaveData(SaveSystem.PlayerGameObject.transform.position.x.ToString(), "PlayerPosX");
        SaveSystem.SaveData(SaveSystem.PlayerGameObject.transform.position.y.ToString(), "PlayerPosY");
        SaveSystem.SaveData(SaveSystem.PlayerGameObject.transform.position.z.ToString(), "PlayerPosZ");
    }

    public void SaveObject()
    {
        foreach (Item skill in SaveSystem.Objects)
        {
            SaveSystem.SaveData(skill.NumberOfObject.ToString(), skill.ItemName);
        }
    }

    public void SaveHealth()
    {
        SaveSystem.SaveData(SaveSystem.Health.PlayerCurrentHealth.ToString(), "PlayerCurrentHealth");
        SaveSystem.SaveData(SaveSystem.Health.PlayerMaxHealth.ToString(), "PlayerMaxHealth");
    }

    public void SaveAllData()
    {
        SavePlayerPos();
        SaveObject();
        SaveHealth();
    }
}