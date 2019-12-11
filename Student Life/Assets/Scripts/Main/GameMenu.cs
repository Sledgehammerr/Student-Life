﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject JobPanel;
    public GameObject ShopPanel;

    private Player player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    void Update()
    {
        
    }

    bool IsAnyPanelOpen
    {
        get
        {
            if (ShopPanel.activeSelf || JobPanel.activeSelf)
            {
                return true;
            }
            else return false;
        }
        
    }

    public void SleepButton()
    {
        player.ChangeStat(0, 20, -10, 50);
        player.PartsOfDay++;
    }

    public void StudyButton()
    {

    }

    public void JobButton()
    {
        if (JobPanel.activeSelf)
        {
            JobPanel.SetActive(false);
        }
        else
        {
            JobPanel.SetActive(true);
            ShopPanel.SetActive(false);
        }
    }

    public void ShopButton()
    {
        if (ShopPanel.activeSelf)
        {
            ShopPanel.SetActive(false);
        }
        else
        {
            JobPanel.SetActive(false);
            ShopPanel.SetActive(true);
        }
    }

    public void EndGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }


}
