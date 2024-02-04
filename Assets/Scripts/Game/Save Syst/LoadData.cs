using System;
using System.Globalization;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour
{
    #region Unity Public
    public DataManager SaveSystem;
    #endregion

    private bool LoadAtStart = true;

    public void Update()
    {
        if (!SaveSystem.StartSaveSys && LoadAtStart)
        {
            LoadAllData();
            LoadAtStart = false;
            SaveSystem.StartAtLoad = true;
        }
    }

    public void LoadPlayerPos()
    {
        float PlayerPosX = SaveSystem.LoadFloat("PlayerPosX");
        float PlayerPosY = SaveSystem.LoadFloat("PlayerPosY");
        float PlayerPosZ = SaveSystem.LoadFloat("PlayerPosZ");
        SaveSystem.PlayerGameObject.transform.position = new Vector3(PlayerPosX,PlayerPosY,PlayerPosZ);
    }

    public void LoadObject()
    {
        foreach (Item skill in SaveSystem.Objects)
        {
            if (SaveSystem.LoadInt(skill.ItemName) == 0 && skill.ItemName == "Damage") skill.NumberOfObject = 1;
            else if (SaveSystem.LoadInt(skill.ItemName) == 0 && skill.ItemName == "Shield") skill.NumberOfObject = 1;
            else if (SaveSystem.LoadInt(skill.ItemName) == 0 && skill.ItemName == "Level") skill.NumberOfObject = 1;
            else if (SaveSystem.LoadInt(skill.ItemName) == 0 && skill.ItemName == "Coins") skill.NumberOfObject = 1;

            else skill.NumberOfObject = SaveSystem.LoadInt(skill.ItemName);
        }
    }

    public void LoadHealth()
    {
        SaveSystem.Health.PlayerCurrentHealth = SaveSystem.LoadFloat("PlayerCurrentHealth");
        if (SaveSystem.LoadFloat("PlayerMaxHealth") < 100)
        {
            SaveSystem.Health.PlayerMaxHealth = 100f;
            SaveSystem.Health.PlayerCurrentHealth = 100;
        }
        else
        {
            SaveSystem.Health.PlayerMaxHealth = SaveSystem.LoadFloat("PlayerMaxHealth");
        }
    }

    public void LoadAllData()
    {
        LoadObject();
        LoadHealth();
        LoadPlayerPos();
    }
}