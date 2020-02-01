﻿using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject login;

    public TMP_InputField inputUserName;

    private Player player;

    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        Application.targetFrameRate = 60;
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void PlayButton()
    {
        menu.SetActive(false);
        //if (SaveLoadManager.TryLoad())//todo Save Try
        //{
        //    SceneManager.LoadScene(1);
        //}
        //else
        //{
        //    login.SetActive(true);
        //}
        login.SetActive(true);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
    }

    public void LoginButton()
    {
        if (inputUserName.text.Length > 3 && inputUserName.text.Length < 15)
        {
            player.UserName = inputUserName.text;
            player.Init();
            //SaveLoadManager.SaveGame();//todo Save
            SaveManager saveManager = new SaveManager();
            saveManager.SaveObject(Game.CurrentPlayer);
            SceneManager.LoadScene(1);
            
        }
    }
}
