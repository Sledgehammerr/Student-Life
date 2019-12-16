using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    private Player player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void SaveGame()
    {
        PlayerPrefs.SetString("Username", player.UserName);
        PlayerPrefs.SetInt("Money", player.Money);
        PlayerPrefs.SetInt("Health", player.Health);
        PlayerPrefs.SetInt("Satiety", player.Satiety);
        PlayerPrefs.SetInt("Stamina", player.Stamina);
        PlayerPrefs.SetInt("Day", player.Date.Day);
        PlayerPrefs.SetInt("Month", player.Date.Month);
        PlayerPrefs.SetInt("Year", player.Date.Year);
        PlayerPrefs.SetInt("PartOfDay", player.PartsDay);
        PlayerPrefs.Save();
    }
    
    private void LoadGame()
    {
        player.UserName = PlayerPrefs.GetString("Username");
        player.Money = PlayerPrefs.GetInt("Money");
        player.Health = PlayerPrefs.GetInt("Health");
        player.Satiety = PlayerPrefs.GetInt("Satiety");
        player.Stamina = PlayerPrefs.GetInt("Stamina");
        player.Date = new DateTime(PlayerPrefs.GetInt("Year"), PlayerPrefs.GetInt("Month"), PlayerPrefs.GetInt("Day"));
        player.PartsDay = PlayerPrefs.GetInt("PartOfDay");
    }

    public bool TryLoad()
    {
        if (PlayerPrefs.HasKey("Username"))
        {
            LoadGame();
            return true;
        }
        return false;
    }
}
