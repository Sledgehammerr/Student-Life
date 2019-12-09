using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveLoadManager
{
    public static void SaveGame()
    {
        PlayerPrefs.SetString("Username", Player.UserName);
        PlayerPrefs.SetInt("Money", Player.Money);
        PlayerPrefs.SetInt("Health", Player.Health);
        PlayerPrefs.SetInt("Satiety", Player.Satiety);
        PlayerPrefs.SetInt("Stamina", Player.Stamina);
        PlayerPrefs.SetInt("Day", Player.Date.Day);
        PlayerPrefs.SetInt("Month", Player.Date.Month);
        PlayerPrefs.SetInt("Year", Player.Date.Year);
        PlayerPrefs.SetInt("PartOfDay", Player.PartsOfDay);
        PlayerPrefs.Save();
    }
    
    public static void LoadGame()
    {
        Player.UserName = PlayerPrefs.GetString("Username");
        Player.Money = PlayerPrefs.GetInt("Money");
        Player.Health = PlayerPrefs.GetInt("Health");
        Player.Satiety = PlayerPrefs.GetInt("Satiety");
        Player.Stamina = PlayerPrefs.GetInt("Stamina");
        Player.Date = new DateTime(PlayerPrefs.GetInt("Year"), PlayerPrefs.GetInt("Month"), PlayerPrefs.GetInt("Day"));
        Player.PartsOfDay = PlayerPrefs.GetInt("PartOfDay");
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
