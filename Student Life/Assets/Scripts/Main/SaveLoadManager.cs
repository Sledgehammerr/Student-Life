using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface SavedObject
{
    void Save();
}

public static class SaveLoadManager
{
    public static void SaveGame()
    {
        PlayerPrefs.SetString("Username", Player.playerInstance.UserName);
        PlayerPrefs.SetInt("Money", Player.playerInstance.Money);
        PlayerPrefs.SetInt("Health", Player.playerInstance.Health);
        PlayerPrefs.SetInt("Satiety", Player.playerInstance.Satiety);
        PlayerPrefs.SetInt("Stamina", Player.playerInstance.Stamina);
        PlayerPrefs.SetInt("Day", Player.playerInstance.Date.Day);
        PlayerPrefs.SetInt("Month", Player.playerInstance.Date.Month);
        PlayerPrefs.SetInt("Year", Player.playerInstance.Date.Year);
        PlayerPrefs.SetInt("PartOfDay", Player.playerInstance.PartsDay);
        PlayerPrefs.SetFloat("Grade", (float)Player.playerInstance.Grade);
        PlayerPrefs.Save();
    }
    
    private static void LoadGame()
    {
        Player.playerInstance.UserName = PlayerPrefs.GetString("Username");
        Player.playerInstance.Money = PlayerPrefs.GetInt("Money");
        Player.playerInstance.Health = PlayerPrefs.GetInt("Health");
        Player.playerInstance.Satiety = PlayerPrefs.GetInt("Satiety");
        Player.playerInstance.Stamina = PlayerPrefs.GetInt("Stamina");
        Player.playerInstance.Date = new DateTime(PlayerPrefs.GetInt("Year"), PlayerPrefs.GetInt("Month"), PlayerPrefs.GetInt("Day"));
        Player.playerInstance.PartsDay = PlayerPrefs.GetInt("PartOfDay");
        Player.playerInstance.Grade = PlayerPrefs.GetFloat("Grade");
    }

    public static bool TryLoad()
    {
        if (PlayerPrefs.HasKey("Username"))
        {
            LoadGame();
            return true;
        }
        return false;
    }
}
